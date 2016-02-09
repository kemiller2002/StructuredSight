﻿using StackExchange.Profiling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdventureWorks.Controllers
{
    [RoutePrefix("Meta")]
    public class MetaInformationController : BaseApiController
    {
        [Route("ProfilerDb")]
        public string GetProfilerDb()
        {

            System.IO.File.WriteAllText(@"C:\temp\db.sql",
                StackExchange.Profiling.Storage.SqlServerStorage.TableCreationScript
                );

            return StackExchange.Profiling.Storage.SqlServerStorage.TableCreationScript;
        }

        [AcceptVerbs("GET")]
        [Route("Diagnostic")]
        public string DiagnosticTest()
        {

            CreateDbCommand();

           return "OK";
        }







    }
}
