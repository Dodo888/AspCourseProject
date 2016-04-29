using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspCourseProject.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: null,
            //    url: "Page{page}",
            //    defaults: new { Controller = "Person", action = "List", category = (string)null, status = (string)null }
            //    );

            //routes.MapRoute(
            //    name: null,
            //    url: "{status}/Page{page}",
            //    defaults: new { Controller = "Person", action = "List", category = (string)null }
            //    );

            //routes.MapRoute(
            //    name: null,
            //    url: "{category}",
            //    defaults: new {Controller = "Person", action = "List", page = 1, status = (string)null }
            //    );
            //routes.MapRoute(
            //    name: null,
            //    url: "{category}/{status}",
            //    defaults: new { Controller = "Person", action = "List", page = 1 }
            //    );

            //routes.MapRoute(
            //    name: null,
            //    url: "{category}/Page{page}",
            //    defaults: new {Controller = "Person", action = "List", status = (string)null }
            //    );
            routes.MapRoute(
                name: "a1",
                url: "{category}/{status}/Page{page}",
                defaults: new {Controller = "Person", action = "List", category="all", status="all", page = 1}
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Person", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}
