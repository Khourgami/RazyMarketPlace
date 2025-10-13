// RazySoft.Market.Admin.Web/Services/ApiResponse.cs

namespace RazySoft.Market.Admin.Web.Services
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; }
        public T? Data { get; }
        public string? ErrorMessage { get; }

        private ApiResponse(bool isSuccess, T? data, string? errorMessage)
        {
            IsSuccess = isSuccess;
            Data = data;
            ErrorMessage = errorMessage;
        }

        public static ApiResponse<T> Success(T data) => new(true, data, null);
        public static ApiResponse<T> Error(string message) => new(false, default, message);
    }
}