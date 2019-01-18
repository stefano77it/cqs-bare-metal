using System;
using ProjX.SimulationEngine;
using ProjX.SimulationEngine.Api.Contracts.v1;
using CSharpFunctionalExtensions;
using log4net;

namespace ProjX.SimulationEngine.Api.Caller.v1
{
    public partial class ApiServer2 : IApiServer
    {
        public Result<SaveBookCommandResult, SaveBookCommandError> SaveBook (SaveBookCommand command)
        {
            return new SaveBookCommandHandler(_Context).Handle(command);
        }
    }
}
