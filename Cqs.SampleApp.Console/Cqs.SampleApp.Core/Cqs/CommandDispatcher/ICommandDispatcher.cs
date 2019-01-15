using System.Windows.Input;

namespace Cqs.SampleApp.Core
{
    /// <summary>
    /// Passed around to all allow dispatching a command and to be mocked by unit tests
    /// </summary>
    public interface ICommandDispatcher
    {
        /// <summary>
        /// Dispatches a command to its handler
        /// </summary>
        IResult Dispatch(ICommand command);
    }
}