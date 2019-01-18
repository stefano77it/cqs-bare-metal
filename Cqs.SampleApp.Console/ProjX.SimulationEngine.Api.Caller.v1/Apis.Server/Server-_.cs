using System;
using ProjX.SimulationEngine;
using ProjX.SimulationEngine.Api.Contracts.v1;
using CSharpFunctionalExtensions;
using log4net;

namespace ProjX.SimulationEngine.Api.Caller.v1
{
    public partial class ApiServer: IApiServer
    {
        private ApplicationContext _Context { get; }
        private QueryDispatcher _QueryDispatcher { get; }
        private CommandDispatcher _CommandDispatcher { get; }
        private readonly ILog _Log;

        public ApiServer() 
        {
            _Context = new ApplicationContext();
            _QueryDispatcher = new QueryDispatcher();
            _CommandDispatcher = new CommandDispatcher();
            _Log = LogManager.GetLogger(GetType().FullName);
        }
    }
}
