using MediatR;

namespace KarlArt.Core.Application.Features.Attachments.Commands.Add;
public class AddAttachmentRequest : IRequest<Result<AddAttachmentResponse>>
{
    public AddAttachmentRequest(Guid patientId, string fileName, Stream fileStream)
    {
        PatientId = patientId;
        FileName = fileName;
        FileStream = fileStream;
    }
    public AddAttachmentRequest(Guid patientId, (string, Stream) file)
    {
        PatientId = patientId;
        (FileName, FileStream) = file;
    }

    public Guid PatientId { get; set; }
    public string FileName { get; set; } = string.Empty;
    public Stream FileStream { get; set; } = Stream.Null;
}
