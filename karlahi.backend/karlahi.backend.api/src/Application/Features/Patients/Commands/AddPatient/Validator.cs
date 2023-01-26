using KarlArt.Core.Application.Common.Constants;
using FluentValidation;

namespace KarlArt.Core.Application.Features.Patients.Commands.AddPatient;
public class Validator : AbstractValidator<AddPatientRequest>
{
    public Validator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(ErrorMessage.Patient.NAME_IS_REQUIRED);
        RuleFor(x => x.LastName).NotEmpty().WithMessage(ErrorMessage.Patient.LAST_NAME_IS_REQUIRED);
    }
}