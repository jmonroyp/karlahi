using KarlArt.Core.Application.Common.Interfaces.UseCases.Attachments;
using KarlArt.Core.Application.Common.Interfaces.UseCases.Common;
using KarlArt.Core.Application.Common.Responses;
using MediatR;

namespace KarlArt.Core.Application.Features.Attachments.Commands.Add;
public class Handler : IRequestHandler<AddAttachmentRequest, Result<AddAttachmentResponse>>
{
    private readonly IUploadFileToStorageUseCase _uploadFileToStorage;
    private readonly IPerformAuditToEntityUseCase _performAuditToEntity;
    private readonly IAddAttachmentUseCase _addAttachment;

    public Handler(IUploadFileToStorageUseCase uploadFileToStorage, IPerformAuditToEntityUseCase performAuditToEntity, IAddAttachmentUseCase addAttachment)
    {
        _uploadFileToStorage = uploadFileToStorage;
        _performAuditToEntity = performAuditToEntity;
        _addAttachment = addAttachment;
    }

    public Task<Result<AddAttachmentResponse>> Handle(AddAttachmentRequest request, CancellationToken cancellationToken) =>
        AsyncResult.ExecuteAsync<CloudFile>(() => _uploadFileToStorage.ExecuteAsync((StorageCategories.Attachments, request.PatientId.ToString(), request.FileName, request.FileStream)))
            .MapAsync(file => Task.FromResult(new Attachment(request.PatientId, file.Name, file.Url)))
            .BindAsync(entity => _performAuditToEntity.ExecuteAsync(entity))
            .BindAsync(entity => _addAttachment.ExecuteAsync(entity as Attachment ?? default!))
            .MapAsync(entity => Task.FromResult((new AddAttachmentResponse(entity.Id, entity.PatientId, entity.FileName, entity.AttachmentUrl))));

}