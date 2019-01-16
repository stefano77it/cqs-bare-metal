using System;
using CqsBareMetal.Apis.v1;
using CSharpFunctionalExtensions;
using System.Linq;
using System.Collections.Generic;

namespace CqsBareMetal.Server
{
    internal class GetBooksQueryHandler : IQueryHandler
    {
        internal GetBooksQueryHandler()
        {
        }

        internal Result<GetBooksQueryResult, GetBooksQueryError> Handle(ApplicationDbContext context, GetBooksQuery request)
        {
            List<GetBooksQueryResult.Book> books = new List<GetBooksQueryResult.Book>();
            if (request.ShowOnlyInPossession)
            {
                foreach (Book elem in context.Books)
                {
                    if (elem.InMyPossession)
                    {
                        books.Add(new GetBooksQueryResult.Book(elem.Title, elem.InMyPossession));
                    }
                }
            }
            else
            {
                foreach (Book elem in context.Books)
                { books.Add(new GetBooksQueryResult.Book(elem.Title, elem.InMyPossession)); }
            }

            return Result.Ok<GetBooksQueryResult, GetBooksQueryError>(new GetBooksQueryResult(books));
        }
    }
}
