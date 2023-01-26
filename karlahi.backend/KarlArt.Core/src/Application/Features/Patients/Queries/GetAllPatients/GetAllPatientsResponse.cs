
using KarlArt.Core.Application.Features.Patients.Common;

namespace KarlArt.Core.Application.Features.Patients.Queries.GetAllPatients;
public class GetAllPatientsResponse
{
    public Guid Id { get; set; }
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
    public bool FirstVisit { get; set; }
    // public IList<EvolutionNoteResponse> EvolutionNotes { get; set; } = new EvolutionNoteResponse[0];
    // public IList<OdontogramNoteResponse> OdontogramNotes { get; set; } = new OdontogramNoteResponse[0];
    // public IList<AttachmentResponse> Attachments { get; set; } = new AttachmentResponse[0];
    public string Age { get; set; } = string.Empty;
    public bool IsQueued { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class EvolutionNoteResponse
{
    public string Presentation { get; set; } = string.Empty;
    public SexResponse Sex { get; set; }
    public string Syntoms { get; set; } = string.Empty;
    public string RecordObservation { get; set; } = string.Empty;
    public string Analisys { get; set; } = string.Empty;
    public string Plan { get; set; } = string.Empty;
    public string Age { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class OdontogramNoteResponse
{
    public string OdontogramDraw { get; set; } = string.Empty;
    public string OdontogramDescription { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class AttachmentResponse
{
    public string[] AttachmentUrl { get; set; } = new string[0];
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
