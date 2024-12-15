namespace Api.Core
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string[] Errors { get; set; }
        public BaseResponse()
        {
            Success = true;
        }
    }
    public class BaseResponse<T> : BaseResponse
    {

        public BaseResponse(T response)
        {
            Success = true;
            Data = response;
        }
        public T Data { get; set; }
    }

}
