using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using AdventureWorks;
using NLog;
using NLog.Fluent;

namespace AdventureWorks
{

    public static class CallLinking
    {
        public static Guid GetCallGuid()
        {
            if (HttpContext.Current.Items.Contains(Constants.ContextCallKey))
            {
                return Guid.Parse(HttpContext.Current.Items[Constants.ContextCallKey].ToString());
            }
            else
            {
                var corrId = Guid.NewGuid();
                HttpContext.Current.Items.Add(Constants.ContextCallKey, corrId);

                return corrId;
            }
        }

        public static Guid GetParentCallId()
        {
            if (HttpContext.Current.Request.Headers[Constants.ContextCallKey] == null)
            {
                HttpContext.Current.Request.Headers.Add(Constants.ContextCallKey, Guid.Empty.ToString());
            }

            var id = HttpContext.Current.Request.Headers[Constants.ContextCallKey];
            return Guid.Parse(id);
        }

    }

    public abstract class MessageHandler : DelegatingHandler
    {

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var corrId = CallLinking.GetCallGuid();

            //C# 6 interpolation instead of using String.Format;
            var requestInfo = $"{request.Method} {request.RequestUri}";

            var requestMessage = await request.Content.ReadAsByteArrayAsync();

            await IncommingMessageAsync(request.Method.ToString(), request.RequestUri.ToString(), corrId, requestInfo, requestMessage);

            var response = await base.SendAsync(request, cancellationToken);

            byte[] responseMessage;

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    responseMessage = new byte[0];
                }
                else
                {
                    responseMessage = await response.Content.ReadAsByteArrayAsync();
                }
            }
            else
            {
                responseMessage = Encoding.UTF8.GetBytes(response.ReasonPhrase);
            }

            await OutgoingMessageAsync(corrId, requestInfo, responseMessage, response.StatusCode.ToString());

            return response;
        }


        protected abstract Task IncommingMessageAsync(string action, string uri, Guid correlationId, string requestInfo, byte[] message);
        protected abstract Task OutgoingMessageAsync(Guid correlationId, string requestInfo, byte[] message, string status);
    }



    public class MessageLoggingHandler : MessageHandler
    {

        protected static bool PushCommand(string command, IEnumerable<SqlParameter> parms)
        {
            try
            {
                using (var conn = new SqlConnection(Constants.SystemMonitoringConnectionString))
                {
                    conn.Open();

                    var cmd = new SqlCommand
                    {
                        Connection = conn,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = command
                    };

                    cmd.Parameters.AddRange(parms.ToArray());

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("MessageHandler").Log(LogLevel.Error, ex, "Message Handler", null);

            }

            return false;
        }


        protected override async Task IncommingMessageAsync(string action, string uri, Guid correlationId, string requestInfo, byte[] message)
        {
            await Task.Run(() =>
            {
                PushCommand("[dbo].[CallLogEntryInsert]",
                    new SqlParameter[]
                    {
                        new SqlParameter("@CallLogEntryTypeId", SqlDbType.Int) {Value = 1},
                        new SqlParameter("@Message", SqlDbType.VarChar)
                        {
                            Value = System.Text.Encoding.Default.GetString(message)
                        },
                        new SqlParameter("@RequestIdentifier", SqlDbType.UniqueIdentifier) {Value = correlationId}
                        ,new SqlParameter("@Action", SqlDbType.VarChar) {Value = action}
                        ,new SqlParameter("@Uri", SqlDbType.VarChar) {Value = uri}

                    });
            });
        }


        protected override async Task OutgoingMessageAsync(Guid correlationId, string requestInfo, byte[] message, string status)
        {
            await Task.Run(() => PushCommand("[dbo].[CallLogEntryInsert]",
                    new SqlParameter[]
                    {
                        new SqlParameter("@CallLogEntryTypeId", SqlDbType.Int) {Value = 2},
                        new SqlParameter("@Message", SqlDbType.VarChar)
                        {
                            Value = System.Text.Encoding.Default.GetString(message)
                        },
                        new SqlParameter("@RequestIdentifier", SqlDbType.UniqueIdentifier) {Value = correlationId},
                        new SqlParameter("@StatusCode", SqlDbType.VarChar) {Value = status}

                    }));
        }
    }
}