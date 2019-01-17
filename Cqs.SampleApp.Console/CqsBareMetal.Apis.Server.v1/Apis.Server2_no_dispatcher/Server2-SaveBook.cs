using System;
using CqsBareMetal.Server;
using CqsBareMetal.Apis.v1;
using CSharpFunctionalExtensions;
using log4net;

namespace CqsBareMetal.Apis.Server.v1
{
    public partial class ApiServer2 : IApiServer
    {
        public Result<SaveBookCommandResult, SaveBookCommandError> SaveBook (SaveBookCommand command)
        {
            return new SaveBookCommandHandler(_Context).Handle(command);
        }
    }
}
