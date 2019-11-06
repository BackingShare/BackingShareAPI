using Backing_Share___API.Repositories;
using System;
//Add The following Namespaces to the project
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Net.Http;

namespace Backing_Share___API.Helpers
{
    public class AudioHelper : IAudioHelper
    { 
        private IAudioRepository _audioRepository;
        public AudioHelper(IAudioRepository audioRepository)
        {
            _audioRepository = audioRepository;
        }

        public async Task CreateAsync(IConfiguration configuration)
        {
            // Create Reference to Azure Storage Account
            string strorageconn = configuration.GetConnectionString("StorageConnectionString");
            CloudStorageAccount storageacc = CloudStorageAccount.Parse(strorageconn);

            //Create Reference to Azure Blob
            CloudBlobClient blobClient = storageacc.CreateCloudBlobClient();

            //The next 2 lines create if not exists a container named "democontainer"
            CloudBlobContainer container = blobClient.GetContainerReference("blobconteiner");

            await container.CreateIfNotExistsAsync();

            //The next 7 lines upload the file test.txt with the name DemoBlob on the container "democontainer"
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("teste");
            using (var filestream = System.IO.File.OpenRead(@"C:\DEV\test.txt"))
            {

                await blockBlob.UploadFromStreamAsync(filestream);
          
            }
        }

        public async Task GetAsync()
        {
            HttpClient client = new HttpClient();
             
            var result = await client.GetAsync("https://reanaarmazenamento.blob.core.windows.net/blobconteiner/teste");

            
        }

     
    }
}
