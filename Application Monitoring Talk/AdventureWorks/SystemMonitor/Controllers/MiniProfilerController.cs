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
using System.Web;
using System.Web.Http;
using TCC.SystemMonitor.Models;
using TCC.SystemMonitor.Models.DataAccess;
using TCC.SystemMonitor.Models.DataObjects;

#endregion

//using ClosedXML.Excel;

namespace TCC.SystemMonitor.Controllers
{
    [RoutePrefix("MiniProfiler")]
    public class MiniProfilerController : BaseApiController
    {
        [Route("Profiler/{id}")]
        [AcceptVerbs("get")]
        public IEnumerable<MiniProfiler> GetMiniProfiler(Guid id)
        {
            var miniProfilerData = new MiniProfilerAccess(GetDataAccess());

            return miniProfilerData.GetMiniProfiler(id);
        }

        [Route("Profiler")]
        [AcceptVerbs("get")]
        public IEnumerable<MiniProfiler> GetDates(DateTime beginDate, DateTime endDate)
        {
            var miniProfilerData = new MiniProfilerAccess(GetDataAccess());
            return miniProfilerData.GetDates(beginDate, endDate).ToList();
        }

        [Route("ProfilerLiveData")]
        [AcceptVerbs("get")]
        public IEnumerable<MiniProfiler> GetLiveData()
        {
            var MiniProfilerData = new MiniProfilerAccess(GetDataAccess());
            return MiniProfilerData.GetLiveData().ToList();

        }

        [Route("ProfilerXL")]
        [AcceptVerbs("get")]
        public void Dates(DateTime beginDate, DateTime endDate)
        {
            var miniProfilerData = new MiniProfilerAccess(GetDataAccess());

            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.ClearContent();

            HttpContext.Current.Response.ContentType =
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Current.Response.AddHeader("content-disposition",
                "attachment;filename=ActiveEmployeeReport.xlsx");

            var ws = ExcelOperations.CreateExcelDocument(() => miniProfilerData.GetDates(beginDate, endDate),
                "Mini Profiler Information");

            ws.Workbook.SaveAs(HttpContext.Current.Response.OutputStream);
            HttpContext.Current.Response.Flush();
        }

        [Route("Profiler")]
        [AcceptVerbs("get")]
        public IEnumerable<MiniProfiler> GetMiniProfilerData()
        {
            var miniProfilerData = new MiniProfilerAccess(GetDataAccess());

            return miniProfilerData.GetMiniProfilerData();
        }

        [Route("Profiler/started")]
        [AcceptVerbs("get")]
        public MiniProfilerData GetDataAsOf()
        {
            var miniProfilerDataAsOf = new MiniProfilerDataAsOfAccess(GetDataAccess());

            return miniProfilerDataAsOf.GetDataAsOf().First();
        }
    }
}