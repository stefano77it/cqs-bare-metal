using System;
using System.Collections.Generic;
using CqsBareMetal.Apis.v1;

namespace CqsBareMetal.Server
{
    public class ApplicationContext
    {
        // properties accessible to all other internal classes
        internal Dictionary<Guid, ICommand> ProcessedCommands { get; }

        public List<Book> Books { get; }

        public ApplicationContext()
        {
            Books = new List<Book>();
            ProcessedCommands = new Dictionary<Guid, ICommand>();
        }
    }
}
