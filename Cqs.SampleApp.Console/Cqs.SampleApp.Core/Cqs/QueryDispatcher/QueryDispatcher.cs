using System;
using CSharpFunctionalExtensions;
using CqsBareMetal.Apis.v1;

namespace CqsBareMetal.Server
{
    public class QueryDispatcher
    {
        public QueryDispatcher()
        { }

        public Result<TResult, TError> Dispatch<TResult, TError>(ApplicationDbContext context, IQuery query)
        {
            ApplicationDbContext _Context = context ?? throw new ArgumentNullException(nameof(context));

            if (query == null) throw new ArgumentNullException(nameof(query));

            Result<TResult, TError> ret;

            switch (query)
            {
                case GetBooksQuery qry:
                    GetBooksQueryHandler handler = new GetBooksQueryHandler();
                    ret = ConvertResult(handler.Handle(_Context, qry));
                    break;
                default:  // if the value is not recognized
                    throw new ArgumentException(nameof(query));
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
