using System;

namespace ProjX.SimulationEngine.Api.Contracts.v1
{
    public class SaveBookCommand : Command_Base
    {
        public string Title { get; }
        public bool InMyPossession { get; }

        public SaveBookCommand(string title, bool inMyPossession) : base()
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));  // can't be null
            InMyPossession = inMyPossession;  // not null by type
        }
    }
}

