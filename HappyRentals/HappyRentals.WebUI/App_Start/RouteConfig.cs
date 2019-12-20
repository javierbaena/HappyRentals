using System.Web.Mvc;
using System.Web.Routing;

namespace HappyRentals.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "Page{page}", new { Controller = "HomeOwner", action = "List" });

            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "HomeOwner", action="List", id = UrlParameter.Optional });
        }
    }
}