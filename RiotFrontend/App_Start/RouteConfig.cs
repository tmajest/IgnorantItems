using System.Web.Mvc;
using System.Web.Routing;

namespace CoffeeCat.RiotFrontend
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "matches",
                url: "matches/{summonerName}/{matchId}",
                defaults: new { controller = "Match", action = "Index", summonerName="", matchId="" });

            routes.MapRoute(
                name: "champions",
                url: "champions",
                defaults: new { controller = "Champions", action = "Index", id=""});

            routes.MapRoute(
                name: "championInfo",
                url: "champions/{id}",
                defaults: new { controller = "ChampionInfo", action = "Index", id=""});

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id=""});
        }
    }
}
