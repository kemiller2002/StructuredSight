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
using System.Linq;
using System.Web.Http;
using TCC.SystemMonitor.Models.DataAccess;
using TCC.SystemMonitor.Models.DataObjects;

#endregion

namespace TCC.SystemMonitor.Controllers
{
    [RoutePrefix("SystemLogging")]
    public class SystemLoggingController : BaseApiController
    {
        [Route("Profiler/{Id}")]
        [AcceptVerbs("get")]
        public IEnumerable<SystemLogging> GetSystemLogging(int Id)
        {
            var callLogEntryData = new SystemLoggingAccess(GetDataAccess());

            return callLogEntryData.GetSystemLogging(Id);
        }

        [Route("Profiler")]
        [AcceptVerbs("get")]
        public IEnumerable<SystemLogging> GetDates(DateTime beginDate, DateTime endDate)
        {
            var callLogEntryData = new SystemLoggingAccess(GetDataAccess());

            return callLogEntryData.GetDates(beginDate, endDate);
        }

        [Route("Profiler")]
        [AcceptVerbs("get")]
        public IEnumerable<SystemLogging> GetSystemLogging()
        {
            var callLogEntryData = new SystemLoggingAccess(GetDataAccess());

            return callLogEntryData.GetSystemLogging();
        }

        [Route("Profiler/date")]
        [AcceptVerbs("get")]
        public SystemLoggingData GetDataAsOf()
        {
            var callLogEntryData = new SystemLoggingDataAsOfAccess(GetDataAccess());

            return callLogEntryData.GetDataAsOf().FirstOrDefault();
        }

    }
}