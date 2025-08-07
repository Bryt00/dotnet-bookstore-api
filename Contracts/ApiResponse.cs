namespace bookapi_minimal.Contracts
{public class ApiResponse<T>
{
    public T? Data { set; get; }
    public String? Message { set; get; }

    public ApiResponse(T data, string message)
    {
        Data = data;
        Message = message;
    }
}}