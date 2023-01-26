using System.Reflection;
using KarlArt.Core.Application.Common.Models;

namespace KarlArt.Core.Api.Common;
public class GetQueryString : BaseGetQueryString
{
     public static ValueTask<GetQueryString> BindAsync(HttpContext context, ParameterInfo parameter) {
        var queryString = new GetQueryString();
        queryString.Q = context.Request.Query["q"].ToString();
        queryString.Sort = context.Request.Query["sort"].ToString();
        queryString.Page = context.Request.Query["page"].Any() ? int.Parse(context.Request.Query["page"].ToString()) : 1;
        queryString.PageSize = context.Request.Query["pageSize"].Any() ? int.Parse(context.Request.Query["pageSize"].ToString()) : 10;
        queryString.Fields = context.Request.Query["fields"].ToString().Split(',');
        return new ValueTask<GetQueryString>(queryString);
     }
}