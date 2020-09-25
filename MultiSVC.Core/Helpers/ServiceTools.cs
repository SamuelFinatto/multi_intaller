using MultiSVC.Core.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceProcess;
using System.Text;

namespace MultiSVC.Core.Helpers
{
    public static class ServiceTools
    {
        public static bool IsServiceInstalled(this Service service)
        {
            ServiceController ctl = ServiceController
                                    .GetServices()
                                    .FirstOrDefault(s => s.ServiceName == service.ServiceName);
            return !(ctl == null);
        }


    }
}
