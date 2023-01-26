using AutoMapper;
using KarlArt.Core.Application.Common.Interfaces.UseCases.Common;
using KarlArt.Core.Application.Common.Interfaces.UseCases.Patients;
using KarlArt.Core.Application.Common.Responses;
using MediatR;

namespace KarlArt.Core.Application.Features.Patients.Commands.AddPatient;
public class Handler : IRequestHandler<AddPatientRequest, Result<AddPatientResponse>>
{
    private readonly IPerformAuditToEntityUseCase _performAuditToEntityUseCase;
    private readonly IAddPatientUseCase _addPatientUseCase;
    private readonly IMapper _mapper;

    public Handler(IPerformAuditToEntityUseCase performAuditToEntityUseCase, IAddPatientUseCase addPatientUseCase, IMapper mapper)
    {
        _performAuditToEntityUseCase = performAuditToEntityUseCase;
        _addPatientUseCase = addPatientUseCase;
        _mapper = mapper;
    }

    public Task<Result<AddPatientResponse>> Handle(AddPatientRequest request, CancellationToken cancellationToken) =>
        AsyncResult.WithAsync<Patient>(() => Task.FromResult(_mapper.Map<Patient>(request)))
            .BindAsync(entity => _performAuditToEntityUseCase.ExecuteAsync(entity))
            .BindAsync(entity => _addPatientUseCase.ExecuteAsync(entity as Patient ?? default!))
            .BindAsync(entity => Task.FromResult(Result<AddPatientResponse>.Success(_mapper.Map<AddPatientResponse>(entity))));
}
