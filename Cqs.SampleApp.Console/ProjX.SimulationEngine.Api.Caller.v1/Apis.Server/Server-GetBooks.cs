using System;
using ProjX.SimulationEngine;
using ProjX.SimulationEngine.Api.Contracts.v1;
using CSharpFunctionalExtensions;
using log4net;

namespace ProjX.SimulationEngine.Api.Caller.v1
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
                string errorMsg = $"Error in {this.GetType()} queryHandler. Message: {_exception.Message} \n Stacktrace: {_exception.StackTrace}";
                _Log.ErrorFormat(errorMsg);
                return Result.Fail<GetBooksQueryResult, GetBooksQueryError>(GetBooksQueryError.Set_InternalServerError(errorMsg));  // return internal server error
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
