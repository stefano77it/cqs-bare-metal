using System;

namespace CqsBareMetal.Apis.v1
{
    public class SaveBookCommand : Command
    {
        public string Title { get; }
        public bool InMyPossession { get; }

        public SaveBookCommand(string title, bool inMyPossession)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));  // can't be null
            InMyPossession = inMyPossession;  // not null by type
        }
    }
}

