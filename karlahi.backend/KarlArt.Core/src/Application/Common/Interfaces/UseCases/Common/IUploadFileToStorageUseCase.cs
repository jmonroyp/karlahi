using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarlArt.Core.Application.Common.Interfaces.UseCases.Common;
public interface IUploadFileToStorageUseCase : IUseCase<(string, string, string, Stream), Result<CloudFile>>
{
}
