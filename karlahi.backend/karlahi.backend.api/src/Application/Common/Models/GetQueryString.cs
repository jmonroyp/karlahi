using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KarlArt.Core.Application.Common.Interfaces.Models;

namespace KarlArt.Core.Application.Common.Models;
public class BaseGetQueryString : IGetQueryString
{
    public string Q { get; set; } = string.Empty;
    public string Sort { get; set; } = string.Empty;
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string[] Fields { get; set; } = null!;
}