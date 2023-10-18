using Microsoft.WindowsAzure.Storage;

namespace FixAzureStorageRangedResponses
{
    [TestClass]
    public class AzureStorage
    {
        [TestMethod]
        public async Task SetDefaultStorageVersion20130815()
        {
            // Setting this property enables Azure Storage to properly handle HTTP Ranged Content request/responses.
            // See https://stackoverflow.com/questions/17408927/do-http-range-headers-work-with-azure-blob-storage-shared-access-signatures

            const string StorageAccountName = "";
            const string StorageAccountKey = "";


            var credentials = new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(StorageAccountName, StorageAccountKey);
            var account = new Microsoft.WindowsAzure.Storage.CloudStorageAccount(credentials, true);
            var client = account.CreateCloudBlobClient();
            var properties = await client.GetServicePropertiesAsync();
            properties.DefaultServiceVersion = "2013-08-15";
            await client.SetServicePropertiesAsync(properties);

        }
    }
}