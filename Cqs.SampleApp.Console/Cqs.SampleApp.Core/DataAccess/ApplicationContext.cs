using System.Collections.Generic;

namespace CqsBareMetal.Server
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