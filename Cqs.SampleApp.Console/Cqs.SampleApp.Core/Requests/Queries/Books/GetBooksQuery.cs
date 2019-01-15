using System.Collections.Generic;

namespace Cqs.SampleApp.Core
{
    public class GetBooksQuery : Query
    {
        public bool ShowOnlyInPossession { get; set; }
        
        //other filters here
    }
}