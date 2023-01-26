using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarlArt.Core.Application.Features.Attachments.Commands.Add;
public class AddAttachmentResponse
{
    public AddAttachmentResponse(Guid id, Guid patientId, string fileName, string attachmentUrl)
    {
        Id = id;
        PatientId = patientId;
        FileName = fileName;
        AttachmentUrl = attachmentUrl;
    }
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string AttachmentUrl { get; set; } = string.Empty;
}