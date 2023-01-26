using KarlArt.Core.Application.Common.Interfaces.Repositories;
using KarlArt.Core.Domain.Entities;
using MongoDB.Driver;

namespace KarlArt.Core.Infrastructure.Repositories;
public class EvolutionNoteRepository : NestedMongoRepository<Patient, EvolutionNote>, IEvolutionNoteRepository
{
    public EvolutionNoteRepository(IMongoDatabase database) : base(database)
    {
    }
}
