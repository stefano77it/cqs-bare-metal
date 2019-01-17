using System;
using System.Collections.Generic;
using CqsBareMetal.Apis.v1;
using CSharpFunctionalExtensions;

namespace CqsBareMetal.Apis.Server.v1
{
    public interface IApiServer
    {
        Result<GetBooksQueryResult, GetBooksQueryError> GetBooks(GetBooksQuery query);
        Result<SaveBookCommandResult, SaveBookCommandError> SaveBook(SaveBookCommand command);
    }
}