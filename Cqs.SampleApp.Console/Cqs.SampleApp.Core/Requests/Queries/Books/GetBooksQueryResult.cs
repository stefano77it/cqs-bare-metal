using System.Collections.Generic;

namespace CqsBareMetal.Server
{
    public class GetBooksQueryResult : IResult
    {
        public IEnumerable<Book> Books { get; set; }
    }
}