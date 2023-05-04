using System.Net;

namespace CQRSProject.API.Utils;

public class ResultStatus
{
    public ResultStatus(HttpStatusCode statusCode, bool isSuccess, string[] details)
    {
        StatusCode = statusCode;
        IsSuccess = isSuccess;
        Details = details;
    }

    public ResultStatus(HttpStatusCode statusCode, bool isSuccess)
    {
        StatusCode = statusCode;
        IsSuccess = isSuccess;
    }

    private HttpStatusCode StatusCode { get; set; }
    private bool IsSuccess { get; set; }
    private string[] Details { get; set; }
}

public class Result<TSuccess, TError>
{
    private readonly ResultStatus _status;
    private readonly TSuccess _successValue;
    private readonly TError _errorValue;

    private Result(ResultStatus status, TSuccess successValue, TError errorValue)
    {
        _status = status;
        _successValue = successValue;
        _errorValue = errorValue;
    }

    private Result(ResultStatus status)
    {
        _status = status;
    }

    public static Result<TSuccess, TError> Success(TSuccess value, HttpStatusCode statusCode = HttpStatusCode.OK,
        string[] details = default)
    {
        return new Result<TSuccess, TError>(new ResultStatus(statusCode, true, details), value, default(TError));
    }

    public static Result<TSuccess, TError> Success(TSuccess value, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return new Result<TSuccess, TError>(new ResultStatus(statusCode, true), value, default(TError));
    }

    public static Result<TSuccess, TError> Success(TSuccess value)
    {
        return new Result<TSuccess, TError>(new ResultStatus(HttpStatusCode.OK, true), value, default(TError));
    }

    public static Result<TSuccess, TError> Success(HttpStatusCode statusCode = HttpStatusCode.OK,
        string[] details = default)
    {
        return new Result<TSuccess, TError>(new ResultStatus(statusCode, true, details));
    }

    public static Result<TSuccess, TError> Failure(TError error, HttpStatusCode statusCode = HttpStatusCode.BadRequest,
        string[] details = default)
    {
        return new Result<TSuccess, TError>(new ResultStatus(statusCode, false, details), default(TSuccess), error);
    }

    public static Result<TSuccess, TError> Failure(HttpStatusCode statusCode = HttpStatusCode.BadRequest,
        string[] details = default)
    {
        return new Result<TSuccess, TError>(new ResultStatus(statusCode, false, details));
    }
}