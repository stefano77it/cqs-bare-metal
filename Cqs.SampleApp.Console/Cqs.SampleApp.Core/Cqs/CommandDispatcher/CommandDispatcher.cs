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

        public Result<TResult, TError> Dispatch<TResult, TError>(ApplicationDbContext context, ICommand command)
        {
            ApplicationDbContext _Context = context ?? throw new ArgumentNullException(nameof(context));

            if (command == null) throw new ArgumentNullException(nameof(command));

            Result<TResult, TError> ret;

            switch (command)
            {
                case SaveBookCommand cmd:
                    SaveBookCommandHandler handler = new SaveBookCommandHandler();
                    ret = ConvertResult(handler.Handle(_Context, cmd));
                    break;
                default:  // if the value is not recognized
                    throw new ArgumentException(nameof(command));
            }

            return ret;

            // local function to intercept mismatch from the server reply and the expected type
            Result<TResult, TError> ConvertResult(object result)
            {
                if (!(result is Result<TResult, TError>)) throw new InvalidOperationException("server call error, return not of the expected type");
                Result<TResult, TError> _result = (Result<TResult, TError>)result;  // cast to correct type
                return _result;
            }
        }
    }
}