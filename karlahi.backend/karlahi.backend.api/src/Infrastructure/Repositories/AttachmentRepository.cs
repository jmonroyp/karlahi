using KarlArt.Core.Application.Common.Interfaces.Repositories;
using KarlArt.Core.Domain.Entities;
using MongoDB.Driver;

namespace KarlArt.Core.Infrastructure.Repositories;
public class AttachmentRepository : NestedMongoRepository<Patient, Attachment>, IAttachmentRepository
{
    public AttachmentRepository(IMongoDatabase database) : base(database)
    {
    }
}
