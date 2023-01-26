namespace KarlArt.Core.Domain.Entities;
public class Payment : BaseEntity
{
    public Customer Customer { get; set; } = default!;
    public Card Card { get; set; } = default!;
    public decimal Amount { get; set; }
    public string Description { get; set; } = default!;
    public Guid OrderId { get; set; } = Guid.NewGuid();
    public string DeviceSessionId { get; set; } = default!;
}