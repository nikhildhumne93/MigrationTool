using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;

namespace MigrationTool
{
    public class AzureOpp
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["BlobStorageConnectionString"].ConnectionString;
        private static string containerName = ConfigurationManager.AppSettings["BlobContainerName"].ToString().Trim();
        private static string folderPath = ConfigurationManager.AppSettings["BlobFolderPath"].ToString().Trim();
        public string GetJsonFileFromBlob(string fileName)
        {
            //JObject json = new JObject();
            string validjsonText = "";
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            //The specified container does not exist
            fileName = System.Web.HttpUtility.UrlPathEncode(fileName);
            //fileName = fileName.Contains(' ') ? fileName.Replace(' ', "%20") : fileName;
            string absolutePath = string.IsNullOrEmpty(folderPath) ? "/" + containerName + "/" + fileName : "/" + containerName + "/" + folderPath + "/" + fileName;
            try
            {
                //root directory
                CloudBlobDirectory dira = container.GetDirectoryReference(string.Empty);
                //true for all sub directories else false 
                var rootDirFolders = dira.ListBlobsSegmentedAsync(true, BlobListingDetails.Metadata, null, null, null, null).Result;
                var blob = rootDirFolders.Results.FirstOrDefault(x => x.Uri.AbsolutePath.ToString() == absolutePath);
                if (blob == null)
                {
                    throw new Exception(fileName + " file is not exist");
                }

                //if (blob != null && blob.GetType() == typeof(CloudBlockBlob))
                //{
                //    if (blob.GetType() == typeof(CloudBlockBlob))
                //    {
                CloudBlockBlob b = (CloudBlockBlob)blob;
                string jsonText = b.DownloadTextAsync().Result;
                //json = JObject.Parse(jsonText);
                //    }
                //}

                jsonText = jsonText.ReplaceWord();
                validjsonText = ValidateJSon.IsValidJson(jsonText) ? jsonText : "invalid_json";

            }
            catch (Exception e)
            {
                //  Block of code to handle errors
                Console.WriteLine("Error:" + e.Message);


            }

            return validjsonText;
        }


    }
}
