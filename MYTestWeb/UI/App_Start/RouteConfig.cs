﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            
            routes.MapRoute(
                name: "Error",
                url: "Error/{id}",
                defaults: new { controller = "Error", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Pages",
                url: "Manager.html",
                defaults: new { controller = "Pages", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Manager", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}