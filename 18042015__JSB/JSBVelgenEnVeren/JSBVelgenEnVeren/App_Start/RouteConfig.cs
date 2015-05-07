using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JSBVelgenEnVeren
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "PayOption",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Terms", action = "PayOption", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "ShoppingCartRemoveItem",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ShoppingCart", action = "RemoveFromCart", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "ShoppingCartIndex",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ShoppingCart", action = "Index", id = UrlParameter.Optional }
                );
        }
    }
}
