using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CRUDWebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Custom route for listing books
            routes.MapRoute(
                name: "ListBooks",
                url: "Books",
                defaults: new { controller = "Book", action = "Index" }
            );

            // Custom route for viewing book details
            routes.MapRoute(
                name: "ViewBookDetails",
                url: "Books/{id}",
                defaults: new { controller = "Book", action = "Details" },
                constraints: new { id = @"\d+" } // Restrict id to numeric values
            );

            // Custom route for creating a new book
            routes.MapRoute(
                name: "CreateBook",
                url: "Books/Create",
                defaults: new { controller = "Book", action = "Create" }
            );

            // Custom route for editing an existing book
            routes.MapRoute(
                name: "EditBook",
                url: "Books/Edit/{id}",
                defaults: new { controller = "Book", action = "Edit" },
                constraints: new { id = @"\d+" } // Restrict id to numeric values
            );

            // Custom route for deleting an existing book
            routes.MapRoute(
                name: "DeleteBook",
                url: "Books/Delete/{id}",
                defaults: new { controller = "Book", action = "Delete" },
                constraints: new { id = @"\d+" } // Restrict id to numeric values
            );

            // Default route (if none of the above routes match)
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
