using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KarlArt.Core.Application.Common.Models;

namespace KarlArt.Core.Application.Common.Interfaces.UseCases.Common;
public interface IUseCase<TRequest, TResponse>
{
    Task<TResponse> ExecuteAsync(TRequest request);
}