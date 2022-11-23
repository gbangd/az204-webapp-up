using Azure.Storage.Blobs;

namespace ImageCreator.ExternalServices
{
    public class BlobStorageService: IBlobStorageService
    {
        public BlobContainerClient GetBlobContainerClient(string connectionString, string containerName)
            => new BlobContainerClient(connectionString, containerName);

        public async Task<Uri> UploadStream(BlobContainerClient containerClient, 
                                                Stream fileStream, string fileName)
        {
            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            await blobClient.UploadAsync(fileStream, true);
            fileStream.Close();
            return blobClient.Uri;
        }

        public async Task<Stream> DownloadStream(BlobContainerClient containerClient, string fileName)
        {
            try
            {
                BlobClient blobClient = containerClient.GetBlobClient(fileName);
                MemoryStream fileStream = new MemoryStream();
                await blobClient.DownloadToAsync(fileStream);
                fileStream.Close();

                return fileStream;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}