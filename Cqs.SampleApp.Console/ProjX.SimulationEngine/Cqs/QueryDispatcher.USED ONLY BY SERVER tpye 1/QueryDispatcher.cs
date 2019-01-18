using System;
using CSharpFunctionalExtensions;
using ProjX.SimulationEngine.Api.Contracts.v1;

namespace ProjX.SimulationEngine
{
    public class QueryDispatcher
    {
        public QueryDispatcher()
        { }

        public Result<TResult, TError> Dispatch<TResult, TError>(ApplicationContext context, IQuery query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            Result<TResult, TError> ret;

            switch (query)
            {
                case GetBooksQuery qry:
                    GetBooksQueryHandler handler = new GetBooksQueryHandler(context);
                    ret = ConvertResult(handler.Handle(qry));
                    break;
                default:  // if the value is not recognized
                    throw new ArgumentException(nameof(query));
            }

            return ret;

            // local function to intercept mismatch from the server reply and the expected type
            Result<TResult, TError> ConvertResult(object result)
            {
                if (!(result is Result<TResult, TError>)) throw new InvalidOperationException("Server error -> Query dispatch error -> return not of the expected type");
                Result<TResult, TError> _result = (Result<TResult, TError>)result;  // cast to correct type
                return _result;
            }
        }
    }
}
