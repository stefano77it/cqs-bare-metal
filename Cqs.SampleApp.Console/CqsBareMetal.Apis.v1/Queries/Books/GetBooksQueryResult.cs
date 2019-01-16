using System;
using System.Linq;
using System.Collections.Generic;

namespace CqsBareMetal.Apis.v1
{
    public class GetBooksQueryResult : IResult
    {
        public IReadOnlyList<Book> Books { get; }

        public GetBooksQueryResult(IEnumerable<Book> books)
        {
            if (books is null) throw new ArgumentNullException(nameof(books));  // can't be null
            Books = books.ToList();
        }

        public class Book
        {
            public string Title { get; }
            public bool InMyPossession { get; }

            public Book(string title, bool inMyPossession)
            {
                Title = title ?? throw new ArgumentNullException(nameof(title));  // can't be null
                InMyPossession = inMyPossession;  // not null by type
            }
        }
    }
}