using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace RegisterForDispose.Models
{
    public class Data
    {
        private readonly SqlConnection _connection;
        public Data(SqlConnection conn)
        {
            _connection = conn;
        }

        public IEnumerable<string> GetNames()
        {
            using (var command = _connection.CreateCommand())
            {

                command.CommandText = "SELECT FirstName FROM Person.Person";

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return reader["FirstName"].ToString();
                }
            }
        }

        public IEnumerable<string> GetNamesWithConnection()
        {
            using(var connection = new SqlConnection("Data Source=localhost;Initial Catalog=AdventureWorks2014;Integrated Security=SSPI"))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "SELECT FirstName FROM Person.Person";

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return reader["FirstName"].ToString();
                }
            }
        }



    }
}