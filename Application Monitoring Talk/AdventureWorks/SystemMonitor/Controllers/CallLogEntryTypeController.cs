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
    [RoutePrefix("CallLogEntryType")]
    public class CallLogEntryTypeController : BaseApiController
    {
        [Route("Profiler/{id}")]
        [AcceptVerbs("get")]
        public IEnumerable<CallLogEntryType> GetCallLogEntryId(Guid id)
        {
            var callLogEntryTypeData = new CallLogEntryIdAccess(GetDataAccess());

            return callLogEntryTypeData.GetCallLogEntryId(id);
        }

        [Route("Profiler")]
        [AcceptVerbs("get")]
        public IEnumerable<CallLogEntryType> GetCallLogEntryData()
        {
            var callLogEntryData = new CallLogEntryIdAccess(GetDataAccess());

            return callLogEntryData.GetCallLogEntryData();
        }

        [Route("hello")]
        [AcceptVerbs("get")]
        public string Hello()
        {
            return "Hello World";
        }
    }
}