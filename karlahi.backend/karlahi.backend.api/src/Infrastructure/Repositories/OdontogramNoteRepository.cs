using KarlArt.Core.Application.Common.Interfaces.Repositories;
using KarlArt.Core.Domain.Entities;
using MongoDB.Driver;

namespace KarlArt.Core.Infrastructure.Repositories;
public class OdontogramNoteRepository : NestedMongoRepository<Patient, OdontogramNote>, IOdontogramNoteRepository
{
    public OdontogramNoteRepository(IMongoDatabase database) : base(database)
    {
    }
}
