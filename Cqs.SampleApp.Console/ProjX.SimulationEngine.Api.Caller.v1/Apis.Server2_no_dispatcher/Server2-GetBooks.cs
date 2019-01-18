using System;
using ProjX.SimulationEngine;
using ProjX.SimulationEngine.Api.Contracts.v1;
using CSharpFunctionalExtensions;
using log4net;

namespace ProjX.SimulationEngine.Api.Caller.v1
{
    public partial class ApiServer2 : IApiServer
    {
        public Result<GetBooksQueryResult, GetBooksQueryError> GetBooks(GetBooksQuery query)
        {
            return new GetBooksQueryHandler(_Context).Handle(query);
        }
    }
}
