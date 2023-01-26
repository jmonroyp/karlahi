
namespace KarlArt.Core.Domain.Entities;

public class S3File : BaseEntity, IAuditableBaseEntity
{
    public string ContentB64 { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public byte[] Content { get { return Convert.FromBase64String(ContentB64); } }
    
    public DateTime CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateTime? UpdatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}