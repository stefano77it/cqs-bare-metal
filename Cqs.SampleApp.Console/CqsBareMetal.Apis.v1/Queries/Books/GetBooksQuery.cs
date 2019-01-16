namespace CqsBareMetal.Apis.v1
{
    public class GetBooksQuery : Query
    {
        public bool ShowOnlyInPossession { get; }

        public GetBooksQuery(bool showOnlyInPossession)
        {
            ShowOnlyInPossession = showOnlyInPossession;  // can't be null, by type
        }
    }
}