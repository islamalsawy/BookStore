using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookStoreWebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*1*/
            routes.MapRoute( // url/
           null,
            "",
            new
            {
                controller = "Book",
                action = "BookView",
                category = (string)null,
                pageno = 1
            }

           );


            /*2*/
            routes.MapRoute(  // url/BookListPage3
          null,
           "BookListPage{pageno}",
           new
           {
               controller = "Book",
               action = "BookView",
               category = (string)null
           }

          );
            /*3*/
            routes.MapRoute(    // url/IS
null,
"{category}",
new
{
    controller = "Book",
    action = "BookView",
    pageno = 1
}

);

            /*4*/
            routes.MapRoute(    // url/IS/page2
                null,
                 "{category}/Page{pageno}",
                 new
                 {
                     controller = "Book",
                     action = "BookView"

                 },
                 new { pageno = @"\d+" }  //one digit or more
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { id = UrlParameter.Optional }
            );
        }
    }
}
