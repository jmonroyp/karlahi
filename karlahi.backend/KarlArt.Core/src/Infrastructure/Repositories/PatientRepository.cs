using KarlArt.Core.Application.Common.Interfaces.Repositories;
using KarlArt.Core.Domain.Entities;
using MongoDB.Driver;

namespace KarlArt.Core.Infrastructure.Repositories;
public class PatientRepository : MongoRepository<Patient>, IPatientRepository
{
    public PatientRepository(IMongoDatabase database) : base(database) { }

    public async Task AddPatientToQueueAsync(Guid patientId)
    {
        var patient = await base.GetByIdAsync(patientId);
        patient.IsQueued = true;
        await base.UpdateAsync(patient);
    }

    public async Task RemovePatientFromQueueAsync(Guid patientId)
    {
        var patient = await base.GetByIdAsync(patientId);
        patient.IsQueued = false;
        await base.UpdateAsync(patient);
    }

    // TODO: Implement specification pattern for this kind of method which require filtering
    public Task<IList<Patient>> GetPatientsByDoctorNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    // TODO: Implement specification pattern for this kind of method which require filtering
    public Task<IList<Patient>> GetPatientsByNameAsync(string name)
    {
        throw new NotImplementedException();
    }
}