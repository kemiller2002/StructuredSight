using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AdventureWorks.Models;
using AdventureWorks.Models.DataTransferObjects;

namespace AdventureWorks.Controllers
{

    [RoutePrefix("Department")]
    public class DepartmentsController : BaseApiController
    {

        [Route("")]
        [AcceptVerbs("GET")]
        public IEnumerable<Department> GetDepartments() =>
            new HumanResourcesModel(CreateDbCommand).GetDepartments();



    }
}
