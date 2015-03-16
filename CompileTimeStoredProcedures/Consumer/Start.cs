using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace Consumer
{


    public class Start
    {
        const string connectString = @"Data Source=localhost\sqlExpress;Initial Catalog=Scheduler;Integrated Security=SSPI;";

        static void Main(string[] args)
        {

            var query = new CompileTimeStoredProcedures.Query.dbo.SelectLogEntry();

            var results = QueryDatabase<CompileTimeStoredProcedures.Result.dbo.SelectLogEntry_Result>(query);

            foreach (var result in results)
            {
                Console.WriteLine(result.ProductName);
            }

            Console.ReadLine();
        }


        public static IEnumerable<T> QueryDatabase<T>(CompileTimeStoredProcedures.IDbQuery query)
        {
            using (var connection = new SqlConnection(connectString))
            {
                connection.Open();
                var command = new SqlCommand();
                command.Connection = connection;

                command.CommandType = System.Data.CommandType.StoredProcedure;
                var sqlParameterCollection = new DynamicParameters();

                foreach (var parameter in query.SqlParameters)
                {
                    sqlParameterCollection.Add(parameter.ParameterName, parameter.Value);
                }


                return connection.Query<T>(query.Query, param: sqlParameterCollection, commandType: System.Data.CommandType.StoredProcedure);

            }

        }



    }
}
