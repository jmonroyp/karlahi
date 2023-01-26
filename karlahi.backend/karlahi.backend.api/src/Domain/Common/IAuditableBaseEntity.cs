namespace KarlArt.Core.Domain.Common;
public interface IAuditableBaseEntity : IBaseEntity
{
    DateTime CreatedAt { get; set; }
    DateTime? UpdatedAt { get; set; }
}