namespace CQRSProject.API.Utils;

public class ApiStatus
{
    public bool Success { get; set; }
    public string Message { get; set; }
}

public class ApiResult
{
    public ApiStatus Status;
}

public class ApiResult<T>
{
    private ApiStatus Status;
    private T Data;

    public static ApiResult<T> SuccessResult(T data)
    {
        return new ApiResult<T>
        {
            Status = new ApiStatus
            {
                Success = true,
                Message = "Success"
            },
            Data = data
        };
    }

    public static ApiResult<T> FailureResult(T data,string message)
    {
        return new ApiResult<T>
        {
            Status = new ApiStatus
            {
                Success = false,
                Message = message ??= "Failure"
            },
            Data = data
        };
    }

    public static ApiResult FailureResult(string message)
    {
        return new ApiResult
        {
            Status = new ApiStatus
            {
                Success = false,
                Message = message ??= "Failure"
            },
        };
    }
}