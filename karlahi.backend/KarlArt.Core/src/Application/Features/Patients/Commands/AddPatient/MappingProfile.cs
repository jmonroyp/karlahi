using AutoMapper;

namespace KarlArt.Core.Application.Features.Patients.Commands.AddPatient;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Patient, AddPatientResponse>();
        CreateMap<AddPatientRequest, Patient>();
    }
}
