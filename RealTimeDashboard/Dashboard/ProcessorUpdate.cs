using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Web;
using System.Web.Hosting;

namespace Dashboard
{
    using Models;

    public class ProcessorUpdate : IRegisteredObject
    {
        private Timer _timer;

        public ProcessorUpdate()
        {

        }

        public void Start()
        {
            HostingEnvironment.RegisterObject(this);

            _timer = new Timer(OnTimerElapsed, null,
               TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
        }

        private void OnTimerElapsed(object sender)
        {
            var number = ProcessorMonitor.GetProcessorMonitor().ProcessorUsage;
            ProcessorHub.SendProcessorUpdate(number);
        }


        public void Stop(bool immediate)
        {
            HostingEnvironment.UnregisterObject(this);
        }
    }
}