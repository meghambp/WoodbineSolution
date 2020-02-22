using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProductManagement
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ProductsList",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "ProductsList", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "AddProduct",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "AddProduct", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "CategoryList",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Category", action = "CategoryList", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "AddCategory",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Category", action = "AddCategory", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "ProductsList", id = UrlParameter.Optional }
            );
        }
    }
}
