namespace KarlArt.Core.Application.Common.Interfaces.Models;
public interface IGetQueryString
{
    public string Q { get; set; }
    public string Sort { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string[] Fields { get; set; }
}