using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorks
{
    public class Constants
    {
        public const String ContextCallKey = "CallContextKey";


        public static string SystemMonitoringConnectionString => System.Configuration.ConfigurationManager.ConnectionStrings["SystemMonitoring"].ConnectionString;

        public static string AdventureWorksConnectionString => System.Configuration.ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString;


    }
}