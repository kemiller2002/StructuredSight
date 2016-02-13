using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using StackExchange.Profiling;
using StackExchange.Profiling.Storage;

namespace AdventureWorks
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        IDisposable profilerStep;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            MiniProfiler.Settings.Storage = new SqlServerStorage("Data Source=localhost;Initial Catalog=SystemMonitoring;Integrated Security=sspi");
        }

        protected void Application_BeginRequest()
        {
            MiniProfiler.Start();

            var identifier = Guid.NewGuid(); 
            NLog.GlobalDiagnosticsContext.Set("systemLogId", identifier);

            MiniProfiler.Current.Id = identifier;

            profilerStep = MiniProfiler.Current.Step("Start");
        }

        protected void Application_EndRequest()
        {
            MiniProfiler.Stop();
        }



    }
}
