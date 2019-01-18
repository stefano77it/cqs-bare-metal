using System;
using System.Collections.Generic;
using ProjX.SimulationEngine.Api.Contracts.v1;

namespace ProjX.SimulationEngine
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
