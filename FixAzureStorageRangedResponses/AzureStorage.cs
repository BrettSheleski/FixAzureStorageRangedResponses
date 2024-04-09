using Microsoft.WindowsAzure.Storage;
using System.Diagnostics;

namespace FixAzureStorageRangedResponses
{
    [TestClass]
    public class AzureStorage
    {
        // Get this from Azure Portal
        const string StorageAccountName = "";

        // Get this from Azure Portal
        const string StorageAccountKey = "";

        
        const string ServiceVersion20130815 = "2013-08-15";

        [TestMethod]
        public async Task SetDefaultStorageVersion20130815()
        {
            // Setting this property enables Azure Storage to properly handle HTTP Ranged Content request/responses.
            // See https://stackoverflow.com/questions/17408927/do-http-range-headers-work-with-azure-blob-storage-shared-access-signatures

            var credentials = new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(StorageAccountName, StorageAccountKey);
            var account = new Microsoft.WindowsAzure.Storage.CloudStorageAccount(credentials, true);
            var client = account.CreateCloudBlobClient();
            var properties = await client.GetServicePropertiesAsync();
            properties.DefaultServiceVersion = ServiceVersion20130815;
            await client.SetServicePropertiesAsync(properties);

        }

        [TestMethod]
        public async Task GetDefaultStorageVersion()
        {
            // Setting this property enables Azure Storage to properly handle HTTP Ranged Content request/responses.
            // See https://stackoverflow.com/questions/17408927/do-http-range-headers-work-with-azure-blob-storage-shared-access-signatures

            var credentials = new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(StorageAccountName, StorageAccountKey);
            var account = new Microsoft.WindowsAzure.Storage.CloudStorageAccount(credentials, true);
            var client = account.CreateCloudBlobClient();
            var properties = await client.GetServicePropertiesAsync();

            Assert.AreEqual(ServiceVersion20130815, properties.DefaultServiceVersion);
        }
    }
}