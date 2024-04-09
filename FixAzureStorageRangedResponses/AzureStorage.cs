using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;

namespace FixAzureStorageRangedResponses
{
    [TestClass]
    public class AzureStorage
    {
        // Setting the DefaultServiceVersion to '2013-08-15' enables Azure Storage to properly
        // handle HTTP Ranged Content request/responses.
        // See https://stackoverflow.com/questions/17408927/do-http-range-headers-work-with-azure-blob-storage-shared-access-signatures


        // Get this from Azure Portal
        const string StorageAccountName = "";

        // Get this from Azure Portal
        const string StorageAccountKey = "";

        
        const string ServiceVersion20130815 = "2013-08-15";

        [TestMethod]
        public async Task SetDefaultStorageVersion20130815()
        {
            // SETUP
            var client = GetBlobClient();
            ServiceProperties properties = await client.GetServicePropertiesAsync();

            // ACT
            properties.DefaultServiceVersion = ServiceVersion20130815;

            await client.SetServicePropertiesAsync(properties);
        }

        [TestMethod]
        public async Task GetDefaultStorageVersion()
        {
            // SETUP
            CloudBlobClient client = GetBlobClient();

            // ACT
            ServiceProperties properties = await client.GetServicePropertiesAsync();


            // VERIFY
            Assert.AreEqual(ServiceVersion20130815, properties.DefaultServiceVersion);
        }

        private static CloudBlobClient GetBlobClient()
        {
            var credentials = new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(StorageAccountName, StorageAccountKey);
            bool useHttps = true;

            return new CloudStorageAccount(credentials, useHttps).CreateCloudBlobClient();
        }
    }
}