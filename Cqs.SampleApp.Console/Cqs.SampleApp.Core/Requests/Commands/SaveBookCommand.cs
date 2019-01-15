using System.Linq;

namespace CqsBareMetal.Server
{
    public class SaveBookCommand : Command
    {
        public Book Book { get; set; }
    }
}