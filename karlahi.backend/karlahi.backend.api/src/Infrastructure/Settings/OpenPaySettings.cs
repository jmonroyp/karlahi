using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarlArt.Core.Infrastructure.Settings;
public class OpenPaySettings
{
    public string MerchantId { get; set; } = default!;
    public string PrivateKey { get; set; } = default!;
}