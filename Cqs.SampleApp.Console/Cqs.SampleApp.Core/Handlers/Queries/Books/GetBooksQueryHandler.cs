using System;
using CqsBareMetal.Apis.v1;
using CSharpFunctionalExtensions;
using System.Linq;
using System.Collections.Generic;

namespace CqsBareMetal.Server
{
    public class GetBooksQueryHandler : QueryHandler_Base<GetBooksQuery, GetBooksQueryResult, GetBooksQueryError>
    {
        public GetBooksQueryHandler(ApplicationContext context) : base(context)
        { }

        // protected method, callable only through base class public methods
        protected override Result<GetBooksQueryResult, GetBooksQueryError>
            DoHandle(GetBooksQuery request)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));  // can't be null

            List<GetBooksQueryResult.Book> books = new List<GetBooksQueryResult.Book>();
            if (request.ShowOnlyInPossession)
            {
                foreach (Book elem in _Context.Books)
                {
                    if (elem.InMyPossession)
                    {
                        books.Add(new GetBooksQueryResult.Book(elem.Title, elem.InMyPossession));
                    }
                }
            }
            else
            {
                foreach (Book elem in _Context.Books)
                { books.Add(new GetBooksQueryResult.Book(elem.Title, elem.InMyPossession)); }
            }

            return Result.Ok<GetBooksQueryResult, GetBooksQueryError>(new GetBooksQueryResult(books));
        }

        // protected method, callable only through base class public methods
        protected override Result<GetBooksQueryResult, GetBooksQueryError> InternalServerError(string errorDetail)
        {
            return Result.Fail<GetBooksQueryResult, GetBooksQueryError>
                (GetBooksQueryError.Set_InternalServerError(errorDetail));
        }
    }
}
