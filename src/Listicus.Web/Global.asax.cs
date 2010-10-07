using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Listicus.Web.Framework;

namespace Listicus.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
//            #if (DEBUG)
//                MapCustomRouteHandlerRoutes();
//            #else
                MapProductionRoutes(routes);
//            #endif

        }

        private static void MapProductionRoutes(RouteCollection routes)
        {
            MapDefaultRoutes(routes);
            MapListControllerRoutes(routes);
            MapHomeControllerRoutes(routes);
        }

        private static void MapListControllerRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                "ListActionId",
                "list/{action}/{id}",
                new { controller="list" },
                new { action = "index|create|edit" },
                new[] { "Listicus.Web.Controllers" }
            );
            routes.MapRoute(
                "ListAction",
                "list/{action}",
                new { controller = "list" },
                new { action = "index|create|edit" },
                new[] { "Listicus.Web.Controllers" }
            );
            routes.MapRoute(
                "ListId",
                "list/{id}",
                new {controller="list",action="index"},
                new[] { "Listicus.Web.Controllers" }
            );
            routes.MapRoute(
                "List",
                "list",
                new { controller = "list", action = "index" },
                new[] { "Listicus.Web.Controllers" }
            );
        }

        private static void MapHomeControllerRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                "HomeActionId",
                "home/{action}/{id}",
                new { controller = "home" },
                new { action = "index|about" },
                new[] { "Listicus.Web.Controllers" }
            );
            routes.MapRoute(
                "HomeAction",
                "home/{action}",
                new { controller = "home" },
                new { action = "index|about" },
                new[] { "Listicus.Web.Controllers" }
            );
            routes.MapRoute(
                "HomeId",
                "home/{id}",
                new { controller = "home", action = "index" },
                new[] { "Listicus.Web.Controllers" }
            );
            routes.MapRoute(
                "Home",
                "home",
                new { controller = "home", action = "index" },
                new[] { "Listicus.Web.Controllers" }
            );
            routes.MapRoute(
                "Id",
                "{id}",
                new {controller = "home", action = "index"},
             //   new { controller = "(?:(?!test|account).)*" },
                new[] { "Listicus.Web.Controllers" }
            );
            routes.MapRoute(
                "Root",
                "",
                new { controller = "home", action = "index" },
                //   new { controller = "(?:(?!test|account).)*" },
                new[] { "Listicus.Web.Controllers" }
            );
        }

        private static void MapDefaultRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                new{controller="account|test|link"},
                new[] { "Listicus.Web.Controllers" } // Controller namespace
            );
        }

        private static void MapCustomRouteHandlerRoutes()
        {

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            //RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);
        }
    }
}