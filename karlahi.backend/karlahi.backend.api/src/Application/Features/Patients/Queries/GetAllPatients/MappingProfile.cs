using AutoMapper;
using KarlArt.Core.Domain.Entities;

namespace KarlArt.Core.Application.Features.Patients.Queries.GetAllPatients;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Patient, GetAllPatientsResponse>();
    }

}