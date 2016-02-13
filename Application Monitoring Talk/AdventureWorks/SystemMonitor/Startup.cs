#region Licensing

// This code is provided under the Attribution-NonCommercial-ShareAlike 4.0 International license.
// 
// https://creativecommons.org/licenses/by-nc-sa/4.0/
// 
// TCC Software Solutions 2015
// 

#endregion

#region

using Microsoft.Owin;
using Owin;
using TCC.SystemMonitor;

#endregion

[assembly: OwinStartup(typeof (Startup))]

namespace TCC.SystemMonitor
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}