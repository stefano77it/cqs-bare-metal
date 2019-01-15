using System.Collections.Generic;

namespace Cqs.SampleApp.Core
{
    public class ApplicationDbContext
    {
        public List<Book> Books { get; set; }

        public ApplicationDbContext()
        {
            Books = new List<Book>();
        }
    }
}