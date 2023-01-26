namespace KarlArt.Core.Application.Common.Interfaces.Services;
public interface IStorageService
{
    Task<string> UploadFileAsync(string containerName, string folderName, string fileName, Stream fileStream);
    Task DeleteFileAsync(string containerName, string fileName);
    Task<Stream> DownloadFileAsync(string containerName, string fileName);
}