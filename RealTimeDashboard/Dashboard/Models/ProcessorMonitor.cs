using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace Dashboard.Models
{



    public class ProcessorMonitor
    {

        PerformanceCounter _processCounter = null;
        private ProcessorMonitor() 
        {
            _processCounter = new PerformanceCounter();

            _processCounter.CategoryName = "Processor";
            _processCounter.CounterName = "% Processor Time";
            _processCounter.InstanceName = "_Total";
        }

        static ProcessorMonitor _processorMonitor = null;

        public float ProcessorUsage
        {
            get { return _processCounter.NextValue(); }
        }

        public static ProcessorMonitor GetProcessorMonitor () {
            if (_processorMonitor == null)
            {
                _processorMonitor = new ProcessorMonitor();
            }

            return _processorMonitor;
        }
    }
}