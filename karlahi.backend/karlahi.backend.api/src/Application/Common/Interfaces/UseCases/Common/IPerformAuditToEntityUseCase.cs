using KarlArt.Core.Application.Common.Models;
using KarlArt.Core.Domain.Common;

namespace KarlArt.Core.Application.Common.Interfaces.UseCases.Common;
public interface IPerformAuditToEntityUseCase : IUseCase<IAuditableBaseEntity, Result<IAuditableBaseEntity>>
{
}