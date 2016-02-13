#region Licensing

// This code is provided under the Attribution-NonCommercial-ShareAlike 4.0 International license.
// 
// https://creativecommons.org/licenses/by-nc-sa/4.0/
// 
// TCC Software Solutions 2015
// 

#endregion

#region

using System.Configuration;
using System.Data.SqlClient;
using System.Net.Http;
using System.Web.Http;
using TCC.SystemMonitor.Models.DataAccess;

#endregion

namespace TCC.SystemMonitor.Controllers
{
    /// <summary>
    /// Base controller for all controllers in project.
    /// Creates database connection, and registers it for disposal when the request is done.
    /// </summary>
    public abstract class BaseApiController : ApiController
    {
        private readonly string _connectionString;

        protected BaseApiController()
        {
            _connectionString =
                ConfigurationManager.ConnectionStrings["SystemMonitor"].ConnectionString;
        }

        /// <summary>
        /// Gets a new version of the data access object it controllers.  
        /// Calling it multiple times returns a new object. 
        /// </summary>
        /// <returns></returns>
        protected DataAccess GetDataAccess()
        {
            var cn = new SqlConnection(_connectionString);

            cn.Open();
            Request.RegisterForDispose(cn);

            return new DataAccess(cn);
        }

    }
}