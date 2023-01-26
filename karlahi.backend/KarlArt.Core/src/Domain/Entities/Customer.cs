using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarlArt.Core.Domain.Entities;
public class Customer : BaseEntity
{
    public string Name { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string City { get; set; } = default!;
    public string State { get; set; } = default!;
    public string PostalCode { get; set; } = default!;
    public string CountryCode { get; set; } = default!;
}