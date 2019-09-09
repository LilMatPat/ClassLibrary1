using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TiltWebsite.App_Start;

namespace TiltWebsite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ApplicationConfig.RegisterApplicationVariables();



         
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            string Username = Session["AUTHUserName"] as string;
            string SessRoles = Session["AUTHRoles"] as string;
            if (string.IsNullOrEmpty(Username))
            {
                return;
            }
            GenericIdentity id = new GenericIdentity(Username, "Matthews TriceratopsAuth");
            if (SessRoles == null) { SessRoles = ""; }
            string[] roles = SessRoles.Split(',');
            GenericPrincipal p = new GenericPrincipal(id, roles);
            HttpContext.Current.User = p;
        }
    }
}
