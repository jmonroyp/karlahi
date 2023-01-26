
using KarlArt.Core.Application.Common.Models;

namespace KarlArt.Core.Application.Common.Interfaces.Models;
public interface IPaginableRequest : IGetRequest
{
    PaginationCriteria PaginationCriteria { get; set; }
}