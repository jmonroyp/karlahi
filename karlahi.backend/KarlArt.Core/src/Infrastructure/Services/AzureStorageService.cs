using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using KarlArt.Core.Application.Common.Interfaces.Services;

namespace KarlArt.Core.Infrastructure.Services;
public class AzureStorageService : IStorageService
{
    private readonly BlobServiceClient _blobServiceClient;

    public AzureStorageService(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient; 
    }

    public async Task<string> UploadFileAsync(string containerName, string folderName, string fileName, Stream fileStream)
    {
        //Generate a sub container for the prefix
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        await containerClient.CreateIfNotExistsAsync(PublicAccessType.BlobContainer);
        var blobClient = containerClient.GetBlobClient($"{folderName}/{fileName}");
        await blobClient.UploadAsync(fileStream, true);
        return blobClient.Uri.ToString();
    }

    public async Task DeleteFileAsync(string containerName, string fileName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        var blobClient = containerClient.GetBlobClient(fileName);
        await blobClient.DeleteIfExistsAsync();
    }

    public async Task<Stream> DownloadFileAsync(string containerName, string fileName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        var blobClient = containerClient.GetBlobClient(fileName);
        var blobDownloadInfo = await blobClient.DownloadAsync();
        return blobDownloadInfo.Value.Content;
    }
}