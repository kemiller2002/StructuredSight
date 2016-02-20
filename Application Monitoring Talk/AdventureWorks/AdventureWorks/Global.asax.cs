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

            MiniProfiler.Settings.Storage = new SqlServerStorage(Constants.SystemMonitoringConnectionString);

            GlobalConfiguration.Configuration.MessageHandlers.Add(new MessageLoggingHandler());

        }

        protected void Application_BeginRequest()
        {
            MiniProfiler.Start();

            NLog.GlobalDiagnosticsContext.Set("systemLogId", CallLinking.GetCallGuid());

            MiniProfiler.Current.Id = CallLinking.GetCallGuid();
        }

        protected void Application_EndRequest()
        {
            //Stop also takes an optional boolean to discard results in case you don't want to save them.
            MiniProfiler.Stop();
        }



    }
}
