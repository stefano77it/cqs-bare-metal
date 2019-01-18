using System;
using System.Diagnostics;
using log4net;
using ProjX.SimulationEngine.Api.Contracts.v1;
using CSharpFunctionalExtensions;

namespace ProjX.SimulationEngine
{
    public abstract class CommandHandler_Base<TRequest, TResult, TError>
        where TRequest : ICommand
        where TResult : ProjX.SimulationEngine.Api.Contracts.v1.IResult
        where TError : IError
    {
        protected readonly ILog Log;
        protected ApplicationContext _Context;

        protected CommandHandler_Base(ApplicationContext context)
        {
            if (context is null) throw new ArgumentNullException(nameof(context));  // can't be null

            _Context = context;
            Log = LogManager.GetLogger(GetType().FullName);
        }

        public Result<TResult, TError> Handle(TRequest command)
        {
            //var _stopWatch = new Stopwatch();
            //_stopWatch.Start();

            Result<TResult, TError> _response;

            try
            {
                #region validation
                // check that Command is not already executed
                if (_Context.ProcessedCommands.ContainsKey(command.Id))
                    throw new ArgumentException($"{nameof(command)} already processed");
                #endregion

                //do authorization
                //XXX

                //handle the request
                _response = DoHandle(command);

                // add Command to the processed commands
                _Context.ProcessedCommands.Add(command.Id, command);

                //do data dump/storage
                //XXX
            }
            catch (Exception _exception)
            {
                string errorMsg = $"Error in {typeof(TRequest)} commandHandler. Message: {_exception.Message} \n Stacktrace: {_exception.StackTrace}";
                Log.ErrorFormat(errorMsg);
                return InternalServerError(errorMsg);  // return internal server error
            }
            finally
            {
                //_stopWatch.Stop();
            }

            return _response;
        }

        // Actual methods that will be implemented in the sub class
        // Protected, to be called only by this class
        protected abstract Result<TResult, TError> DoHandle(TRequest request);
        protected abstract Result<TResult, TError> InternalServerError(string errorDetail);
    }
}