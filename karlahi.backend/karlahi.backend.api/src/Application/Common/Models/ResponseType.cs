using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarlArt.Core.Application.Common.Models;
public enum ResponseType
{
    Success,
    BadRequest,
    NotFound,
    Unauthorized,
    Forbidden,
    InternalServerError
}