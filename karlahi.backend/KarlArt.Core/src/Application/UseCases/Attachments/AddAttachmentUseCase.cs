using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KarlArt.Core.Application.Common.Interfaces.Repositories;
using KarlArt.Core.Application.Common.Interfaces.UseCases.Attachments;

namespace KarlArt.Core.Application.UseCases.Attachments
{
    public class AddAttachmentUseCase : IAddAttachmentUseCase
    {
        private readonly IAttachmentRepository _attachmentRepository;

        public AddAttachmentUseCase(IAttachmentRepository attachmentRepository)
        {
            _attachmentRepository = attachmentRepository;
        }

        public async Task<Result<Attachment>> ExecuteAsync(Attachment request) =>
            Result<Attachment>.Success(await (await _attachmentRepository.WithRootAsync(request.PatientId)).AddAsync(request));
    }
}