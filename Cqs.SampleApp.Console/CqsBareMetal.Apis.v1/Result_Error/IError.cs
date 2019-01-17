namespace CqsBareMetal.Apis.v1
{
    public interface IError
    {
        string ErrorType { get; }
        string ErrorDetail { get; }
    }
}
