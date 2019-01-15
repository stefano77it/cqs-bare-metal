using System.Collections.Generic;

namespace Cqs.SampleApp.Core
{
    public class GetBooksQueryResult : IResult
    {
        public IEnumerable<Book> Books { get; set; }
    }
}