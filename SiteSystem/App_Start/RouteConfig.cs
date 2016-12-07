using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SiteSystem
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ForumPaging",                               
                url: "Forum/Page/{page}",                           
                defaults: new { controller = "Forum", action = "AjaxIndex" },
                namespaces: new[] { "SiteSystem.Controllers" }
            );

            routes.MapRoute(
                name: "TopicPaging",
                url: "Forum/Info/{id}/Page/{page}",
                defaults: new { controller = "Forum", action = "AjaxInfo" },
                namespaces: new[] { "SiteSystem.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"SiteSystem.Controllers"}
            );
        }
    }
}
