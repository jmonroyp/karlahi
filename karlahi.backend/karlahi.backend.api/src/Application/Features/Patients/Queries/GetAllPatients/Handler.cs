
using AutoMapper;
using KarlArt.Core.Application.Common.Models;
using KarlArt.Core.Application.Common.Interfaces.UseCases.Patients;
using KarlArt.Core.Application.Common.Responses;
using MediatR;
using KarlArt.Core.Application.Common.Mappings;
using KarlArt.Core.Domain.Entities;

namespace KarlArt.Core.Application.Features.Patients.Queries.GetAllPatients;
public class Handler : IRequestHandler<GetAllPatientsRequest, Result<IList<GetAllPatientsResponse>>>
{
    private readonly IGetAllPatientsUseCase _getAllPatientsUseCase;
    private readonly IMapper _mapper;

    public Handler(IGetAllPatientsUseCase getAllPatientsUseCase, IMapper mapper)
    {
        _getAllPatientsUseCase = getAllPatientsUseCase;
        _mapper = mapper;
    }

    public Task<Result<IList<GetAllPatientsResponse>>> Handle(GetAllPatientsRequest request, CancellationToken cancellationToken) =>
        AsyncResult.WithAsync(() => _getAllPatientsUseCase.ExecuteAsync(request))
            .BindAsync(_ => {
                var mapped = _mapper.MapList<Patient, GetAllPatientsResponse>(_.Data ?? new List<Patient>());
                return Task.FromResult(Result<IList<GetAllPatientsResponse>>.Success(mapped));
            });
}
