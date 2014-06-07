using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dashboard.Models;
using Microsoft.AspNet.SignalR;

namespace Dashboard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Processor()
        {

            ProcessorHub.SendProcessorUpdate(23);

            return View("index");
        }

    }
}