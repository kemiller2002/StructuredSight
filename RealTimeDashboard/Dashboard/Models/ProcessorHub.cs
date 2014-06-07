using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Dashboard.Models
{
    public class ProcessorHub : Hub
    {
        public void SendProcessor(int percentage)
        {
            Clients.All.broadcastProcessorStats(percentage);
        }

        public static void SendProcessorUpdate(int percentage)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<ProcessorHub>();

            context.Clients.All.broadcastProcessorStats(percentage);
        }

    }
}