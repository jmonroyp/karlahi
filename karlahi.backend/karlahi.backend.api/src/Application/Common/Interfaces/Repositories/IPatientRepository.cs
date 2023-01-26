namespace KarlArt.Core.Application.Common.Interfaces.Repositories;
public interface IPatientRepository : IRepository<Patient>
{
    Task<IList<Patient>> GetPatientsByNameAsync(string name);
    Task<IList<Patient>> GetPatientsByDoctorNameAsync(string name);
    Task AddPatientToQueueAsync(Guid patientId);
    Task RemovePatientFromQueueAsync(Guid patientId);
}
