using KarlArt.Core.Domain.Enums;

namespace KarlArt.Core.Domain.Entities;
public class EvolutionNote : BaseEntity, IAuditableBaseEntity
{
    public string Presentation { get; set; } = string.Empty;
    public Sex Sex { get; set; }
    public string Syntoms { get; set; } = string.Empty;
    public string RecordObservation { get; set; } = string.Empty;
    public string Analisys { get; set; } = string.Empty;
    public string Plan { get; set; } = string.Empty;
    public string Age { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}