using System;

namespace ProjX.SimulationEngine
{
    public class Book
    {
        public string Title { get; }
        public bool InMyPossession { get; set; }

        public Book(string title, bool inMyPossession)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));  // can't be null
            InMyPossession = inMyPossession;  // not null by type
        }
    }
}