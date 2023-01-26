using KarlArt.Core.Application.Common.Models;

namespace KarlArt.Core.Application.Common.Responses;
public static class AsyncResult
{
    public static async Task<Result<TResponse>> ExecuteAsync<TResponse>(Func<Task<Result<TResponse>>> action)
    {
        try
        {
            return await action();
        }
        catch (Exception ex)
        {
            return Result<TResponse>.Failure(new List<string> { ex.Message });
        }
    }

    public static async Task<Result<TResponse>> WithAsync<TResponse>(Func<Task<TResponse>> action)
    {
        try
        {
            return Result<TResponse>.Success(await action());
        }
        catch (Exception ex)
        {
            return Result<TResponse>.Failure(new List<string> { ex.Message });
        }
    }

    public static async Task<Result<TNextResponse>> BindAsync<TResponse, TNextResponse>(this Task<Result<TResponse>> result, Func<TResponse, Task<Result<TNextResponse>>> next)
    {
        var response = await result;
        if (!response.Succeeded)
            return Result<TNextResponse>.Failure(response.Errors);
        return await next(response.Data ?? default!);
    }

    public static async Task<Result<TNextResponse>> MapAsync<TResponse, TNextResponse>(this Task<Result<TResponse>> result, Func<TResponse, Task<TNextResponse>> next)
    {
        var response = await result;
        if (!response.Succeeded)
            return Result<TNextResponse>.Failure(response.Errors);
        return Result<TNextResponse>.Success(await next(response.Data ?? default!));
    }

}