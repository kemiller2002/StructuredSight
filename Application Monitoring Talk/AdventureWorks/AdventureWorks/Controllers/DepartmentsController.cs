using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AdventureWorks.Models;
using AdventureWorks.Models.DataTransferObjects;
using StackExchange.Profiling;

namespace AdventureWorks.Controllers
{

    [RoutePrefix("Department")]
    public class DepartmentsController : BaseApiController
    {

        [Route("")]
        [AcceptVerbs("GET")]
        public IEnumerable<Department> GetDepartments() =>
            new HumanResourcesModel(CreateDbCommand).GetDepartments();

        [Route("Proposed")]
        [AcceptVerbs("Get")]
        public IEnumerable<String> GetProposedDepartment()
        {
            using (MiniProfiler.Current.Step("Proposed Department File Access"))
            {
                var stream = new FileStream(@"C:\temp\ProposedDepartments.txt", FileMode.Open);
                Request.RegisterForDispose(stream);

                return HumanResourcesModel.GetPropDepartments(stream);
            }
        }


    }
}
