
namespace KarlArt.Core.Domain.Entities;
public class OdontogramNote : BaseEntity, IAuditableBaseEntity
{
    public string OdontogramDraw { get; set; } = string.Empty;
    public string OdontogramDescription { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}