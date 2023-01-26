using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarlArt.Core.Domain.Entities;
public class Card : BaseEntity
{
    public string CardNumber { get; set; } = default!;
    public string HolderName { get; set; } = default!;
    public string ExpirationMonth { get; set; } = default!;
    public string ExpirationYear { get; set; } = default!;
    public string Cvv2 { get; set; } = default!;
    public string Type { get; set; } = default!;
}