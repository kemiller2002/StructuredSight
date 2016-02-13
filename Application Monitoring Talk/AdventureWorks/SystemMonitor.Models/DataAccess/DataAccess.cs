#region Licensing

// This code is provided under the Attribution-NonCommercial-ShareAlike 4.0 International license.
// 
// https://creativecommons.org/licenses/by-nc-sa/4.0/
// 
// TCC Software Solutions 2015
// 

#endregion

#region

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

#endregion

namespace TCC.SystemMonitor.Models.DataAccess
{
    public interface IDataAccess
    {
        IEnumerable<T> Get<T>(string procedureName, IEnumerable<KeyValuePair<string, object>> parameters);
        int Execute(string procedureName, IEnumerable<KeyValuePair<string, object>> parameters);
    }

    public sealed class DataAccess : IDataAccess
    {
        private readonly SqlConnection _connection;

        public DataAccess(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<T> Get<T>(string procedureName, IEnumerable<KeyValuePair<string, object>> parameters)
        {
            var d = new DynamicParameters();

            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    d.Add(p.Key, p.Value);
                }
            }

            return _connection.Query<T>(procedureName, commandType: CommandType.StoredProcedure, param: parameters);
        }

        public int Execute(string procedureName, IEnumerable<KeyValuePair<string, object>> parameters)
        {
            var d = new DynamicParameters();

            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    d.Add(p.Key, p.Value);
                }
            }

            return _connection.Execute(procedureName, commandType: CommandType.StoredProcedure, param: parameters);
        }
    }
}