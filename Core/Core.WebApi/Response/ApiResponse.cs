namespace Core.WebApi.Response;

public class ApiResponse<T>
{
    public ApiResponse(int statusCode, string message = null, T data = default, List<string> errors = null)
    {
        StatusCode = statusCode;
        Message = message ?? (statusCode == 200 ? "Success" : "An error occurred");
        Data = data;
        Errors = errors;
    }

    public int StatusCode { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    public List<string> Errors { get; set; }

    public static ApiResponse<T> Success(T data, string message = "Success")
    {
        return new ApiResponse<T>(200, message, data);
    }

    public static ApiResponse<T> Fail(string message, List<string> errors = null, int statusCode = 400)
    {
        return new ApiResponse<T>(statusCode, message, default, errors);
    }

    public static ApiResponse<T> Fail(string message, IEnumerable<string> errors = null, int statusCode = 400)
    {
        return new ApiResponse<T>(statusCode, message, default, errors.ToArray().ToList());
    }

    public static ApiResponse<T> Fail(string message, int statusCode = 400)
    {
        return new ApiResponse<T>(statusCode, message, default, []);
    }
}