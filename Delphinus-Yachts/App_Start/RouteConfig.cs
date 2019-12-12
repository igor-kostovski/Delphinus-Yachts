using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Delphinus_Yachts
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Account",
                "Account/{action}/{id}",
                new {controller = "Account", action = "RedirectToLocal", id = UrlParameter.Optional});

            routes.MapRoute(
                name: "Default",
                url: "{entity}/{action}/{id}",
                defaults: new { controller = "Mvc", action = "Index", entity = "Default", id = UrlParameter.Optional }
            );
        }
    }
}
