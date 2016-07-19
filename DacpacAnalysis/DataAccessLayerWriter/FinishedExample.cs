using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Net.Configuration;


namespace dbo
{

    public class SelectEmployees
    {

        readonly SqlConnection _connection;

        public SelectEmployees(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<dynamic> Execute(int? id)
        {
            var command = new SqlCommand();
            command.Connection = _connection;
            command.CommandText = "SelectEmployees";

            if (id.HasValue)
            {
                var parameter = new SqlParameter
                {
                    Value = id,
                    ParameterName = "@id",
                };

                command.Parameters.Add(parameter);
            }


            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                dynamic record = new ExpandoObject();

                for (var ii = 0; ii < reader.FieldCount; ii++)
                {
                    record[reader.GetName(ii)] = reader[ii];
                }

                yield return record;
            }
        }


    }

}