namespace Common.Shared.Interfaces
{
    public interface IResponse
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }
        string AdditionalInfo { get; set; }
        object Data { get; set; }
    }
}
