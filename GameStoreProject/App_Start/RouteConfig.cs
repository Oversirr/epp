using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace GameStore.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Game Details",
                url: "game/{key}",
                defaults: new { controller = "Games", action = "GetGameDetails", key = UrlParameter.Optional }
            );

            routes.MapRoute(
                            name: "Games",
                            url: "games",
                            defaults: new { controller = "Games", action = "GetAllGames" }
                        );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
