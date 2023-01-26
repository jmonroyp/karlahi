using KarlArt.Core.Application.Common.Models;
namespace KarlArt.Core.Api.Common;
public static class Extensions
{
    // extension to parse a Result<T> to a Http Result with a specific status code
    public static IResult ToHttpResult<T>(this Result<T> result) where T : class =>
        result switch
        {
            Result<T> r when r.ResponseType == ResponseType.Success => Results.Ok(r),
            Result<T> r when r.ResponseType == ResponseType.BadRequest => Results.BadRequest(r),
            Result<T> r when r.ResponseType == ResponseType.NotFound => Results.NotFound(r),
            Result<T> r when r.ResponseType == ResponseType.Unauthorized => Results.Forbid(),
            Result<T> r when r.ResponseType == ResponseType.Forbidden => Results.Forbid(),
            Result<T> r when r.ResponseType == ResponseType.InternalServerError => Results.Problem(),
            _ => Results.Problem()
        };

    // method to get file from HttpRequest
    public static async Task<(string, Stream)> GetFileAsync(this HttpRequest request)
    {
        var file = request.Form.Files[0];
        var fileName = file.FileName;
        var fileStream = file.OpenReadStream();
        return await Task.FromResult((fileName, fileStream));
    }
}

