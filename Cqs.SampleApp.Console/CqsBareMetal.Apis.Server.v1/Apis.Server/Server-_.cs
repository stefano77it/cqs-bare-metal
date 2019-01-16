using System;
using CqsBareMetal.Server;
using CqsBareMetal.Apis.v1;
using CSharpFunctionalExtensions;
using log4net;

namespace CqsBareMetal.Apis.Server.v1
{
    public partial class ApiServer
    {
        private ApplicationDbContext _Context { get; }
        private QueryDispatcher _QueryDispatcher { get; }
        private CommandDispatcher _CommandDispatcher { get; }
        private readonly ILog _Log;

        public ApiServer() 
        {
            _Context = new ApplicationDbContext();
            _QueryDispatcher = new QueryDispatcher();
            _CommandDispatcher = new CommandDispatcher();
            _Log = LogManager.GetLogger(GetType().FullName);
        }
    }
}
