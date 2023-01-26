using KarlArt.Core.Application.Common;
using KarlArt.Core.Application.Common.Interfaces.Repositories;
using KarlArt.Core.Application.Common.Interfaces.UseCases.Patients;
using KarlArt.Core.Application.Common.Models;
using KarlArt.Core.Application.Features.Patients.Queries.GetAllPatients;
using KarlArt.Core.Domain.Entities;

namespace KarlArt.Core.Application.UseCases.Patients.GetAll;
public class GetAllPatientsUseCase : IGetAllPatientsUseCase
{
    private readonly IPatientRepository _patientRepository;

    public GetAllPatientsUseCase(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Result<IList<Patient>>> ExecuteAsync(GetAllPatientsRequest request) =>
         Result<IList<Patient>>.Success(await _patientRepository.GetListBySearchCriteriaAsync(request.ToExpression()));
}