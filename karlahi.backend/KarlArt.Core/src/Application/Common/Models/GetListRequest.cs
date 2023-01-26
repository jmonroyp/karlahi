using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KarlArt.Core.Application.Common.Interfaces.Models;

namespace KarlArt.Core.Application.Common.Models;
public abstract class GetListRequest : IGetRequest, IPaginableRequest, ISearchCriteriaRequest
{
    public PaginationCriteria PaginationCriteria { get; set; } = new PaginationCriteria();
    public string SearchCriteria { get; set; } = string.Empty;
}