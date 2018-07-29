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
                defaults: new {controller = "Games", action = "GetGameDetails", key = UrlParameter.Optional}
            );

            routes.MapRoute(
                name: "Create Game",
                url: "games/new",
                defaults: new {controller = "Games", action = "CreateGame", game = UrlParameter.Optional}
            );

            routes.MapRoute(
                name: "Edit Game",
                url: "games/update",
                defaults: new {controller = "Games", action = "EditGame", game = UrlParameter.Optional}
            );

            routes.MapRoute(
                name: "Delete Game",
                url: "games/remove",
                defaults: new {controller = "Games", action = "DeleteGame", game = UrlParameter.Optional}
            );

            routes.MapRoute(
                name: "Games",
                url: "games",
                defaults: new {controller = "Games", action = "GetAllGames"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
            );
        }
    }
}
