
using KarlArt.Core.Application.Common.Interfaces.Repositories;
using KarlArt.Core.Application.Common.Interfaces.UseCases.Patients;
using KarlArt.Core.Application.Common.Models;
using KarlArt.Core.Domain.Entities;

namespace KarlArt.Core.Application.UseCases.Patients.Add;
public class AddPatientUseCase : IAddPatientUseCase
{
    private readonly IPatientRepository _patientRepository;

    public AddPatientUseCase(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Result<Patient>> ExecuteAsync(Patient request) =>
         Result<Patient>.Success(await _patientRepository.AddAsync(request));
}