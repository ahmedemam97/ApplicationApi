
namespace Domain.Dto
{
    public class ResponseResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Obj { get; set; }
    }
}
