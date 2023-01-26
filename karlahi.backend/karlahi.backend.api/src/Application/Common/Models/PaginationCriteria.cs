namespace KarlArt.Core.Application.Common.Models;
public class PaginationCriteria
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public PaginationCriteria()
    {
        PageNumber = 1;
        PageSize = 10;
    }
}