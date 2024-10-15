namespace Store.Domain.Common
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

        public static ServiceResponse<T> SuccessResponse(T data) => new ServiceResponse<T>
        {
            Data = data,
            Success = true
        };

        public static ServiceResponse<T> FailureResponse(string message) => new ServiceResponse<T>
        {
            Success = false,
            Message = message
        };
    }

}
