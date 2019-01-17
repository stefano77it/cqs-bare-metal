using System;
using System.Diagnostics;
using log4net;
using CqsBareMetal.Apis.v1;
using CSharpFunctionalExtensions;

namespace CqsBareMetal.Server
{
    public abstract class QueryHandler_Base<TRequest, TResult, TError>
        where TRequest : IQuery
        where TResult : Apis.v1.IResult
        where TError : IError
    {
        protected readonly ILog Log;
        protected ApplicationContext _Context;

        protected QueryHandler_Base(ApplicationContext context)
        {
            if (context is null) throw new ArgumentNullException(nameof(context));  // can't be null

            _Context = context;
            Log = LogManager.GetLogger(GetType().FullName);
        }

        public Result<TResult, TError> Handle(TRequest query)
        {
            //var _stopWatch = new Stopwatch();
            //_stopWatch.Start();

            Result<TResult, TError> _response;

            try
            {
                //do validation
                //XXX

                //do authorization
                //XXX

                //handle the request
                _response = DoHandle(query);

                //do data dump/storage
                //XXX
            }
            catch (Exception _exception)
            {
                string errorMsg = $"Error in {query.GetType().Name} queryHandler. Message: {_exception.Message} \n Stacktrace: {_exception.StackTrace}";
                Log.ErrorFormat(errorMsg);
                return InternalServerError(errorMsg);  // return internal server error
            }
            finally
            {
                //_stopWatch.Stop();
            }


            return _response;
        }

        // Actual methods that will be implemented in the sub class.
        // Protected, to be called only by this class
        protected abstract Result<TResult, TError> DoHandle(TRequest request);
        protected abstract Result<TResult, TError> InternalServerError(string errorDetail);
    }
}