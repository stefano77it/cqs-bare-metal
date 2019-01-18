using System;
using System.Collections.Generic;
using ProjX.SimulationEngine;
using ProjX.SimulationEngine.Api.Contracts.v1;
using CSharpFunctionalExtensions;
using log4net;

namespace ProjX.SimulationEngine.Api.Caller.v1
{
    public partial class ApiServer2 : IApiServer
    {
        private ApplicationContext _Context { get; }
        private readonly ILog _Log;

        public ApiServer2()
        {
            _Context = new ApplicationContext();
            _Log = LogManager.GetLogger(GetType().FullName);
        }
    }
}
