using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using BookStore.App_Start;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;
using Serilog;

[assembly: PreApplicationStartMethod(typeof(CreateFileInStorage), "CreateFile")]

namespace BookStore.App_Start
{
    public class CreateFileInStorage
    {
        public static void CreateFile()
        {
            var storageConnection = ConfigurationManager.ConnectionStrings["AzureStorageConnection"].ToString();
            
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