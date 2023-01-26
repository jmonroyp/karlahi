using KarlArt.Core.Application.Common.Interfaces.UseCases.Common;
using KarlArt.Core.Application.Common.Models;
using KarlArt.Core.Application.Features.Patients.Queries.GetAllPatients;
using KarlArt.Core.Domain.Entities;

namespace KarlArt.Core.Application.Common.Interfaces.UseCases.Patients;
public interface IGetAllPatientsUseCase : IUseCase<GetAllPatientsRequest, Result<IList<Patient>>>
{

}
