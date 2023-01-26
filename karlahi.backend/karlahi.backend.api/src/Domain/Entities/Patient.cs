using KarlArt.Core.Domain.Enums;

namespace KarlArt.Core.Domain.Entities;
public class Patient : BaseEntity, IAuditableBaseEntity
{
    public Patient(string name, string lastName, DateTime birthDate, string birthPlace)
    {
        Name = name;
        LastName = lastName;
        BirthDate = birthDate;
        BirthPlace = birthPlace;
    }

    public Patient(string name, string lastName)
    {
        Name = name;
        LastName = lastName;
    }

    public Patient()
    {
    }

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
    public PaymentMethod PaymentMethod { get; set; }
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
    public IList<EvolutionNote> EvolutionNotes { get; set; } = new EvolutionNote[0];
    public IList<OdontogramNote> OdontogramNotes { get; set; } = new OdontogramNote[0];
    public IList<Attachment> Attachments { get; set; } = new Attachment[0];
    public string Age { get; set; } = string.Empty;
    public bool IsQueued { get; set; } = false;
    public DateTime? UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}