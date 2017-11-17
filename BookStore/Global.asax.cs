using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
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
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

		    var tableConnectionString = ConfigurationManager.ConnectionStrings["AzureTableConnection"].ToString();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.AzureTableStorage(tableConnectionString, storageTableName: "CriticalErrors")
                .CreateLogger();
		}
	}
}
