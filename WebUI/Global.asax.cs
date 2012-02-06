using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI
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

            // Don't use 'Debriefing' as the root of the form type URL as it confuses MVC
            // and makes it think that /Debriefing/Details/1
            // is a call to ByFormType with id = Details and formType = 1

            routes.MapRoute(
                "EditBySection",
                "Debrief/{id}/Edit/{formType}/",
                new { controller = "Debriefing", action = "EditByFormType" }
            );
            
            routes.MapRoute(
                "BySection",
                "Debrief/{id}/{formType}/",
                new { controller = "Debriefing", action = "ByFormType"}
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}