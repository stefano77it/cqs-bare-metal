using System;
using CSharpFunctionalExtensions;
using CqsBareMetal.Apis.v1;

namespace CqsBareMetal.Server
{
    public class CommandDispatcher
    {
        public CommandDispatcher()
        {
        }

        public Result<TResult, TError> Dispatch<TResult, TError>(ApplicationContext context, ICommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            Result<TResult, TError> ret;

            switch (command)
            {
                case SaveBookCommand cmd:
                    SaveBookCommandHandler handler = new SaveBookCommandHandler(context);
                    ret = ConvertResult(handler.Handle(cmd));
                    break;
                default:  // if the value is not recognized
                    throw new ArgumentException(nameof(command));
            }

            return ret;

            // local function to intercept mismatch from the server reply and the expected type
            Result<TResult, TError> ConvertResult(object result)
            {
                if (!(result is Result<TResult, TError>)) throw new InvalidOperationException("Server error -> Command dispatch error -> return not of the expected type");
                Result<TResult, TError> _result = (Result<TResult, TError>)result;  // cast to correct type
                return _result;
            }
        }
    }
}
