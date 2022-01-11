using Common.Shared.Interfaces;

namespace Common.Shared.Response
{
    public class Response : IResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string AdditionalInfo { get; set; }
        public object Data { get; set; }
    }
}
