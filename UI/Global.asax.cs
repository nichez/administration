using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Itc.Am.DL;
using Itc.Am.UI.App_Start;

namespace Itc.Am.UI.App_Start
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Init database

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            WebSecurityConfig.RegisterWebSec();
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;

            // Autofac and Automapper configurations
            Bootstrapper.Run();
        }
    }
}
 
