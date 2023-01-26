namespace KarlArt.Core.Domain.Entities;
public class Attachment : BaseEntity, IAuditableBaseEntity
{
    public Attachment(Guid patientId, string fileName, string attachmentUrl)
    {
        PatientId = patientId;
        FileName = fileName;
        AttachmentUrl = attachmentUrl;
    }
    
    public Guid PatientId { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string AttachmentUrl { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}