﻿namespace Mvc.UI.jQuery.Examples.SparkView
{
    using System.Web.Mvc;
    using System.Web.Routing;

    using Spark.Web.Mvc;

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Accordion", action = "Basic", id = string.Empty });
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            SparkEngineStarter.RegisterViewEngine();
        }
    }
}