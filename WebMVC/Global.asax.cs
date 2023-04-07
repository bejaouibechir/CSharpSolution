﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
           var user = HttpContext.Current.User;
        }

        protected void Session_End(object sender, EventArgs e)
        {
            var user = HttpContext.Current.User;
        }

        protected void Application_End(object sender, EventArgs e)
        {
            EventLog.WriteEntry("Application", $"Message {DateTime.Now}");
        }



    }
}
