using KarlArt.Core.Domain.Entities;

namespace KarlArt.Core.Application.Common.Interfaces.Repositories;
public interface IEvolutionNoteRepository : INestedRepository<Patient, EvolutionNote>
{
}