using System;
using System.Collections.Generic;
using ProjX.SimulationEngine.Api.Contracts.v1;
using CSharpFunctionalExtensions;

namespace ProjX.SimulationEngine.Api.Caller.v1
{
    public interface IApiServer
    {
        Result<GetBooksQueryResult, GetBooksQueryError> GetBooks(GetBooksQuery query);
        Result<SaveBookCommandResult, SaveBookCommandError> SaveBook(SaveBookCommand command);
    }
}