using KarlArt.Core.Application.Common.Interfaces.UseCases.Common;

namespace KarlArt.Core.Application.Common.Interfaces.UseCases.Patients;
public interface IAddPatientUseCase : IUseCase<Patient, Result<Patient>>
{
}
