using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using RegisterForDispose.Models;

namespace RegisterForDispose.Controllers
{
    [RoutePrefix("Enumeration")]
    public class EnumerationController : ApiController
    {
        [Route("")]
        [AcceptVerbs("Get")]
        public IEnumerable<string> Enumerate()
        {
            using (var connection = new SqlConnection())
            //var connection = new SqlConnection();
            {
                connection.ConnectionString = "Data Source=localhost;Initial Catalog=AdventureWorks2014;Integrated Security=SSPI";
                connection.Open();                

                return GetNamesWithConnection(connection);
            }
        }

        public IEnumerable<string> GetNamesWithConnection(SqlConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT FirstName FROM Person.Person";

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return reader["FirstName"].ToString();
                }
            }
        }

        [Route("ControllerEnumerate")]
        [AcceptVerbs("Get")]
        public IEnumerable<string> EnumerateWithStrings()
        {
            using (var connection = new SqlConnection("Data Source=localhost;Initial Catalog=AdventureWorks2014;Integrated Security=SSPI"))
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



        [Route("InternalConnection")]
        [AcceptVerbs("Get")]
        public IEnumerable<string> EnumerateWithConnection()
        {
            var d = new Data(null);

            return d.GetNamesWithConnection();
        }






    }
}
