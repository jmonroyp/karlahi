using KarlArt.Core.Application.Common.Interfaces.Services;
using KarlArt.Core.Application.Common.Interfaces.UseCases.Common;

namespace KarlArt.Core.Application.UseCases.Common;
public class UploadFileToStorageUseCase : IUploadFileToStorageUseCase
{
    private readonly IStorageService _storageService;

    public UploadFileToStorageUseCase(IStorageService storageService)
    {
        _storageService = storageService;
    }

    //(containerName, folderName, fileName, fileStream)
    public async Task<Result<CloudFile>> ExecuteAsync((string, string, string, Stream) request)
    {
        var (containerName, folderName, fileName, fileStream) = request;
        return Result<CloudFile>.Success(new CloudFile(await _storageService.UploadFileAsync(containerName, folderName, fileName, fileStream)));
    }
}