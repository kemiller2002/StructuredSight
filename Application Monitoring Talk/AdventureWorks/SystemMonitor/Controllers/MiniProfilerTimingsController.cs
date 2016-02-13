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
    [RoutePrefix("MiniProfilerTimings")]
    public class MiniProfilerTimingsController : BaseApiController
    {
        [Route("Profiler/{id}")]
        [AcceptVerbs("get")]
        public IEnumerable<MiniProfilerTimings> GetMiniProfilerTimings(Guid MiniProfilerId)
        {
            var miniProfilerData = new MiniProfilerTimingsSelectAccess(GetDataAccess());

            return miniProfilerData.GetMiniProfilerTimings(MiniProfilerId);
        }

        [Route("Profiler")]
        [AcceptVerbs("get")]
        public IEnumerable<MiniProfilerTimings> GetDates(DateTime beginDate, DateTime endDate)
        {
            var callLogEntryData = new MiniProfilerTimingsSelectAccess(GetDataAccess());

            return callLogEntryData.GetDates(beginDate, endDate);
        }

        [Route("Profiler")]
        [AcceptVerbs("get")]
        public IEnumerable<MiniProfilerTimings> GetMiniProfilerTimingsData(Guid? miniProfilerId = null)
        {
            var miniProfilerTimingsData = new MiniProfilerTimingsSelectAccess(GetDataAccess());

            return miniProfilerTimingsData.GetMiniProfilerTimingsData(miniProfilerId);
        }

    }
}