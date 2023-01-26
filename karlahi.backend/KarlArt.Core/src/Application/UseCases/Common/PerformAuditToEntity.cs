using KarlArt.Core.Application.Common.Interfaces.UseCases.Common;
using KarlArt.Core.Application.Common.Models;
using KarlArt.Core.Domain.Common;

namespace KarlArt.Core.Application.UseCases.Common;
public class PerformAuditToEntity : IPerformAuditToEntityUseCase
{
    public async Task<Result<IAuditableBaseEntity>> ExecuteAsync(IAuditableBaseEntity request)
    {
        if (request.CreatedAt == DateTime.MinValue)
            request.CreatedAt = DateTime.Now;
        request.UpdatedAt = DateTime.Now;
        return await Task.FromResult(Result<IAuditableBaseEntity>.Success(request));
    }
}
