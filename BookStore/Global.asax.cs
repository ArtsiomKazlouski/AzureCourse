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
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;
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

		    var storageConnection = ConfigurationManager.ConnectionStrings["AzureStorageConnection"].ToString();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.AzureTableStorage(storageConnection, storageTableName: "CriticalErrors")
                .CreateLogger();

		    var storageAccount = CloudStorageAccount.Parse(storageConnection);
		    var fileClient = storageAccount.CreateCloudFileClient();
		    var share = fileClient.GetShareReference("logappstartsshare");
		    share.CreateIfNotExists();

		    // Get a reference to the root directory for the share.
		    CloudFileDirectory rootDir = share.GetRootDirectoryReference();

		    // Get a reference to the directory we created previously.
		    CloudFileDirectory sampleDir = rootDir.GetDirectoryReference("CustomLogs");
		    sampleDir.CreateIfNotExists();
		    // Ensure that the directory exists.
		    if (sampleDir.Exists())
		    {
		        var dateString = (DateTime.Now.ToString("s")).Replace(':', '-');

                // Get a reference to the file we created previously.
                CloudFile file = sampleDir.GetFileReference($"Start-{dateString}.txt");
		        try
		        {
                    file.Create(555);
		            file.UploadText($"{Environment.MachineName} - {dateString}");
		        }
		        catch (Exception ex)
		        {
		            var s = ex.Message;
		            throw;
		        }
		    }
        }
	}
}
