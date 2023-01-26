using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KarlArt.Core.Application.Common.Interfaces.Models;
public interface ISearchCriteriaRequest : IGetRequest
{
    string SearchCriteria { get; set; }
}