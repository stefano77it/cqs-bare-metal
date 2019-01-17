using System;
using CqsBareMetal.Server;
using CqsBareMetal.Apis.v1;
using CSharpFunctionalExtensions;
using log4net;

namespace CqsBareMetal.Apis.Server.v1
{
    public partial class ApiServer : IApiServer
    {
        public Result<GetBooksQueryResult, GetBooksQueryError> GetBooks(GetBooksQuery query)
        {
            Result<GetBooksQueryResult, GetBooksQueryError> _queryResult;

            try  // try dispatch of the command
            {
                _queryResult = 
                    _QueryDispatcher.Dispatch<GetBooksQueryResult, GetBooksQueryError>(_Context, query);  //handle the request

            }
            catch (Exception _exception)  // catch every exception
            {
                _Log.ErrorFormat($"Error in {query.GetType().Name} queryHandler. Message: {_exception.Message} \n Stacktrace: {_exception.StackTrace}");

                // return internal server error
                return Result.Fail<GetBooksQueryResult, GetBooksQueryError>(GetBooksQueryError.Set_InternalServerError);
            }
            finally
            {
                // do nothing
            }

            //GetBooksQueryHandler handler = new GetBooksQueryHandler();
            //return handler.Handle(_Context, query);
            return _queryResult;
        }
    }
}
