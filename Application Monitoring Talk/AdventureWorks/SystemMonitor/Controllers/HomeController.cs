#region Licensing

// This code is provided under the Attribution-NonCommercial-ShareAlike 4.0 International license.
// 
// https://creativecommons.org/licenses/by-nc-sa/4.0/
// 
// TCC Software Solutions 2015
// 

#endregion

#region

using System.Web.Mvc;

#endregion

namespace TCC.SystemMonitor.Controllers
{
    public class HomeController : Controller
    {
        // GET: CallLogEntryDashboard
        public ActionResult CallLogEntryDashboard()
        {
            return View();
        }

        //GET: MiniProfilerDashboard
        public ActionResult MiniProfilerDashboard()
        {
            return View();
        }

        //GET: SystemLoggingDashboard
        public ActionResult SystemLoggingDashboard()
        {
            return View();
        }

        public ActionResult Graphs()
        {
            return View();
        }
    }
}