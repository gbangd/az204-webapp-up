using Azure.Storage.Blobs;

namespace ImageCreator.ExternalServices
{
    public interface IBlobStorageService
    {
        BlobContainerClient GetBlobContainerClient(string connectionString, string containerName);

        Task<Uri> UploadStream(BlobContainerClient containerClient, 
                                                Stream fileStream, string fileName);

        Task<Stream> DownloadStream(BlobContainerClient containerClient, string fileName);
    } 
}