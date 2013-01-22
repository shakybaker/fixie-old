using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Fixie.App_Start;
using Fixie.Code.Infrastructure;
using Fixie.Content.App_Start;
using Fixie.Models;
using Microsoft.AspNet.SignalR;

namespace Fixie
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Register the default hubs route: ~/signalr/hubs
            RouteTable.Routes.MapHubs(); 
            
            AreaRegistration.RegisterAllAreas();
            ContainerBootstrap.Bootstrap();
            AuthConfig.RegisterAuth();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<FixieWebContext>());
            Database.SetInitializer(new DropCreateDatabaseAlways<FixieWebContext>());
        }
    }
}