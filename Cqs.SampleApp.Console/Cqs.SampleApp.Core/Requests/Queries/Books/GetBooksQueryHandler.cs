using System.Linq;

namespace CqsBareMetal.Server
{
    public class GetBooksQueryHandler : QueryHandler<GetBooksQuery, GetBooksQueryResult>
    {
        public GetBooksQueryHandler(ApplicationDbContext applicationDbContext) 
            : base(applicationDbContext)
        {
        }

        protected override GetBooksQueryResult DoHandle(GetBooksQuery request)
        {
            var _result = new GetBooksQueryResult();

            var _bookQuery = ApplicationDbContext.Books.AsQueryable();

            if (request.ShowOnlyInPossession)
            {
                _bookQuery = _bookQuery.Where(c => c.InMyPossession);
            }

            _result.Books = _bookQuery.ToList();

            return _result;
        }
    }
}
