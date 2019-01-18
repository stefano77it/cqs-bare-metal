using System;
using ProjX.SimulationEngine;
using ProjX.SimulationEngine.Api.Contracts.v1;
using CSharpFunctionalExtensions;
using log4net;

namespace ProjX.SimulationEngine.Api.Caller.v1
{
    public partial class ApiServer
    {
        public Result<SaveBookCommandResult, SaveBookCommandError> SaveBook (SaveBookCommand command)
        {
            Result<SaveBookCommandResult, SaveBookCommandError> _cmdResult;

            try  // try dispatch of the command
            {
                _cmdResult =
                    _CommandDispatcher.Dispatch<SaveBookCommandResult, SaveBookCommandError>(_Context, command);  //handle the request

            }
            catch (Exception _exception)  // catch every exception
            {
                string errorMsg = $"Error in {this.GetType()} commandHandler. Message: {_exception.Message} \n Stacktrace: {_exception.StackTrace}";
                _Log.ErrorFormat(errorMsg);
                return Result.Fail<SaveBookCommandResult, SaveBookCommandError>(SaveBookCommandError.Set_InternalServerError(errorMsg));  // return internal server error
            }
            finally
            {
                // do nothing
            }

            //SaveBookCommandHandler handler = new SaveBookCommandHandler();
            //return handler.Handle(_Context, cmd);

            return _cmdResult;
        }
    }
}
