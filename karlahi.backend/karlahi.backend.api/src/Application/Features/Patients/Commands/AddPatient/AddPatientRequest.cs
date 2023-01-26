using Bogus;
using KarlArt.Core.Application.Common.Interfaces.Models;
using KarlArt.Core.Application.Features.Patients.Common;
using MediatR;

namespace KarlArt.Core.Application.Features.Patients.Commands.AddPatient;
public class AddPatientRequest : CustomRequest, IRequest<Result<AddPatientResponse>>, IFakeable<AddPatientRequest>
{
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string BirthPlace { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string CellNumber { get; set; } = string.Empty;
    public string Occupation { get; set; } = string.Empty;
    public string SentBy { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
    public string Sickness { get; set; } = string.Empty;
    public string SicknessNotes { get; set; } = string.Empty;
    public PaymentMethodResponse PaymentMethod { get; set; }
    public string Medicine { get; set; } = string.Empty;
    public string MedicineNotes { get; set; } = string.Empty;
    public string Allergies { get; set; } = string.Empty;
    public string AllergiesNotes { get; set; } = string.Empty;
    public string Doctor { get; set; } = string.Empty;
    public string ProfilePic { get; set; } = string.Empty;
    public string Institution { get; set; } = string.Empty;
    public string OdontogramDraw { get; set; } = string.Empty;
    public string OdontogramDescription { get; set; } = string.Empty;
    public string Exploration { get; set; } = string.Empty;
    public string Diagnostic { get; set; } = string.Empty;
    public string Treatment { get; set; } = string.Empty;
    public string Observations { get; set; } = string.Empty;
    public bool FirstVisit { get; set; } = false;
    public string Age { get; set; } = string.Empty;
    public bool IsQueued { get; set; }

    public AddPatientRequest Fake() => new Faker<AddPatientRequest>()
        .RuleFor(x => x.Name, f => f.Person.FirstName)
        .RuleFor(x => x.LastName, f => f.Person.LastName)
        .RuleFor(x => x.BirthDate, f => f.Date.Past())
        .RuleFor(x => x.BirthPlace, f => f.Address.City())
        .RuleFor(x => x.PhoneNumber, f => f.Phone.PhoneNumber())
        .RuleFor(x => x.CellNumber, f => f.Phone.PhoneNumber())
        .RuleFor(x => x.Occupation, f => f.Lorem.Sentence())
        .RuleFor(x => x.SentBy, f => f.Lorem.Sentence())
        .RuleFor(x => x.Reason, f => f.Lorem.Sentence())
        .RuleFor(x => x.Sickness, f => f.Lorem.Sentence())
        .RuleFor(x => x.SicknessNotes, f => f.Lorem.Sentence())
        .RuleFor(x => x.PaymentMethod, f => f.PickRandom<PaymentMethodResponse>())
        .RuleFor(x => x.Medicine, f => f.Lorem.Sentence())
        .RuleFor(x => x.MedicineNotes, f => f.Lorem.Sentence())
        .RuleFor(x => x.Allergies, f => f.Lorem.Sentence())
        .RuleFor(x => x.AllergiesNotes, f => f.Lorem.Sentence())
        .RuleFor(x => x.Doctor, f => f.PickRandom<string>(new string[] { "Dr. Rodolfo", "Dra. Paty" }))
        .RuleFor(x => x.ProfilePic, f => f.Image.PicsumUrl())
        .RuleFor(x => x.Institution, f => f.Lorem.Sentence())
        .RuleFor(x => x.OdontogramDraw, f => "https://socialdentalstudio.com/wp-content/uploads/2017/03/Diapositiva1-960x640.jpg")
        .RuleFor(x => x.OdontogramDescription, f => f.Lorem.Sentence())
        .RuleFor(x => x.Exploration, f => f.Lorem.Sentence())
        .RuleFor(x => x.Diagnostic, f => f.Lorem.Sentence())
        .RuleFor(x => x.Treatment, f => f.Lorem.Sentence())
        .RuleFor(x => x.Observations, f => f.Lorem.Sentence())
        .RuleFor(x => x.FirstVisit, f => f.Random.Bool())
        .RuleFor(x => x.Age, f => f.Random.Int(1, 100).ToString())
        .RuleFor(x => x.IsQueued, f => f.Random.Bool()
    ).Generate();
}