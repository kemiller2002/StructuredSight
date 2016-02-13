#region Licensing

// This code is provided under the Attribution-NonCommercial-ShareAlike 4.0 International license.
// 
// https://creativecommons.org/licenses/by-nc-sa/4.0/
// 
// TCC Software Solutions 2015
// 

#endregion

#region

using System;
using System.Collections.Generic;
using System.Web.Http;
using TCC.SystemMonitor.Models.DataAccess;
using TCC.SystemMonitor.Models.DataObjects;

#endregion

namespace TCC.SystemMonitor.Controllers
{
    [RoutePrefix("MiniProfilerClientTimings")]
    public class MiniProfilerClientTimingsController : BaseApiController
    {
        [Route("Profiler/{id}")]
        [AcceptVerbs("get")]
        public IEnumerable<MiniProfilerClientTimings> GetProfilerById(Guid id)
        {
            var miniProfilerData = new MiniProfilerClientTimingsSelectAccess(GetDataAccess());

            return miniProfilerData.GetMiniProfilerEntry(id);
        }

        [Route("Profiler")]
        [AcceptVerbs("get")]
        public IEnumerable<MiniProfilerClientTimings> GetMiniProfilerClientTimings()
        {
            var MiniProfilerClientTimings = new MiniProfilerClientTimingsSelectAccess(GetDataAccess());

            return MiniProfilerClientTimings.GetMiniProfilerClientTimings();
        }

        [Route("hello")]
        [AcceptVerbs("get")]
        public string Hello()
        {
            return "Hello World";
        }
    }
}