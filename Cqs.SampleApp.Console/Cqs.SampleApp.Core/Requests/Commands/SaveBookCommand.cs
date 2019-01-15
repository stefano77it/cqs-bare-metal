using System.Linq;

namespace Cqs.SampleApp.Core
{
    public class SaveBookCommand : Command
    {
        public Book Book { get; set; }
    }
}