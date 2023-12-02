namespace ColabManager360.Domain.Common.Responses
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }

        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public T Data { get; set; }

        public BaseResponse()
        {
            
        }

        public BaseResponse(T data)
        {
            Data = data;
        }

    }

}
