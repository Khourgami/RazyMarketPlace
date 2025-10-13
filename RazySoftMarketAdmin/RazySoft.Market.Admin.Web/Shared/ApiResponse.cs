namespace RazySoft.Market.Admin.Web.Shared
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; init; }
        public T? Data { get; init; }
        public string? ErrorMessage { get; init; }
        public IDictionary<string, string[]>? ValidationErrors { get; init; }

        public static ApiResponse<T> Success(T data) => new() { IsSuccess = true, Data = data };
        public static ApiResponse<T> Fail(string error, IDictionary<string, string[]>? validation = null) => new() { IsSuccess = false, ErrorMessage = error, ValidationErrors = validation };
    }
}
