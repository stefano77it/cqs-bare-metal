using System.Collections.Generic;

namespace CqsBareMetal.Server
{
    public class GetBooksQuery : Query
    {
        public bool ShowOnlyInPossession { get; set; }
        
        //other filters here
    }
}