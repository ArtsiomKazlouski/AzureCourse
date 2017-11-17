using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BookStore.App_Start;
using BookStore.Models;
using Serilog;

namespace BookStore
{
    public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
            Database.SetInitializer(new BookDbInitializer());
			Database.SetInitializer(new CourseDbInitializer());

			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
		    WebApiConfig.Register(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            var storageConnection = ConfigurationManager.ConnectionStrings["AzureStorageConnection"].ToString();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.AzureTableStorage(storageConnection, storageTableName: "CriticalErrors")
                .CreateLogger();
        }
	}
}
