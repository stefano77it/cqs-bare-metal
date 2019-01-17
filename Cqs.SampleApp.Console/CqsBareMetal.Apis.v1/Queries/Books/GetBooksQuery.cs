namespace CqsBareMetal.Apis.v1
{
    public class GetBooksQuery : Query_Base
    {
        public bool ShowOnlyInPossession { get; }

        public GetBooksQuery(bool showOnlyInPossession)
        {
            ShowOnlyInPossession = showOnlyInPossession;  // can't be null, by type
        }
    }
}