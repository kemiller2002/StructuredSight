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
    [RoutePrefix("CallLogEntry")]
    public class CallLogEntryController : BaseApiController
    {
        [Route("Profiler/{id}")]
        [AcceptVerbs("get")]
        public IEnumerable<CallLogEntrySelect> GetCallLogEntry(Guid id)
        {
            var callLogEntry = new CallLogEntrySelectAccess(GetDataAccess());

            return callLogEntry.GetCallLogEntry(id);
        }

        [Route("Profiler")]
        [AcceptVerbs("get")]
        public IEnumerable<CallLogEntrySelect> GetDates(DateTime beginDate, DateTime endDate)
        {
            var callLogEntryDate = new CallLogEntrySelectAccess(GetDataAccess());

            return callLogEntryDate.GetDates(beginDate, endDate);
        }

        [Route("Profiler")]
        [AcceptVerbs("get")]
        public IEnumerable<CallLogEntrySelect> GetCallLogEntryData()
        {
            var callLogEntryData = new CallLogEntrySelectAccess(GetDataAccess());

            return callLogEntryData.GetCallLogEntryData();
        }

        [Route("Profiler/date")]
        [AcceptVerbs("get")]
        public CallLogEntryData GetDataAsOf()
        {
            var callLogEntryData = new CallLogEntryDataAsOfAccess(GetDataAccess());

            return callLogEntryData.GetDataAsOf().FirstOrDefault();
        }
    }
}