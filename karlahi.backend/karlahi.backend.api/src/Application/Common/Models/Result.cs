namespace KarlArt.Core.Application.Common.Models;

public class Result<T>
{   
    public Result()
    {
        Succeeded = false;
        Data = default(T);
        Errors = new string[0];
    }

    public Result(bool succeeded, T? data, string[] errors)
    {
        Succeeded = succeeded;
        Data = data;
        Errors = errors;
    }

    public Result(IList<string> errors)
    {
        Succeeded = false;
        Data = default(T);
        Errors = errors.ToArray();
    }
    
    internal Result(bool succeeded, T? data, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Data = data;
        Errors = errors.ToArray();
    }

    public bool Succeeded { get; set; }

    public T? Data { get; set; }

    public string[] Errors { get; set; }

    public ResponseType ResponseType
    {
        get
        {
            if (Succeeded)
                return ResponseType.Success;
            if (Errors.Any(x => x.Contains("not found")))
                return ResponseType.NotFound;
            if (Errors.Any(x => x.Contains("unauthorized")))
                return ResponseType.Unauthorized;
            if (Errors.Any(x => x.Contains("forbidden")))
                return ResponseType.Forbidden;
            if (Errors.Any(x => x.Contains("required")))
                return ResponseType.BadRequest;
            return ResponseType.BadRequest;
        }
    }

    public static Result<T> Success(T data)
    {
        return new Result<T>(true, data, new List<string>());
    }

    public static Result<T> Failure(IEnumerable<string> errors)
    {
        return new Result<T>(false, default(T), errors);
    }
}