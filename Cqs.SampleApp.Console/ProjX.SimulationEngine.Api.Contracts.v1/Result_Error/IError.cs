namespace ProjX.SimulationEngine.Api.Contracts.v1
{
    public interface IError
    {
        string ErrorType { get; }
        string ErrorDetail { get; }
    }
}
