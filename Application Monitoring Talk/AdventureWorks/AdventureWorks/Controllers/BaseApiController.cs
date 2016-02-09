using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using NLog;
using StackExchange.Profiling.Data;
using StackExchange.Profiling;

namespace AdventureWorks.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        public BaseApiController()
        {
        }

        protected static Logger Logger = LogManager.GetLogger("Controller");

        protected System.Data.Common.DbCommand CreateDbCommand()
        {
            var connectionString = "Data Source=localhost;Initial Catalog=AdventureWorks2014;Integrated Security=SSPI";
            var sqlConnection = new SqlConnection(connectionString);

            var connection = new StackExchange.Profiling.Data.ProfiledDbConnection
                (sqlConnection, MiniProfiler.Current);

            Request.RegisterForDispose(connection);

            var command = connection.CreateCommand();
            Request.RegisterForDispose(command);

            Logger.Log(new LogEventInfo(LogLevel.Error,"Controller","Connection Returned."));
            connection.Open();
            return command;
        }

    }
}
