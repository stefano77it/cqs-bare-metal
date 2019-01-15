using System;

namespace Cqs.SampleApp.Core
{
    public class QueryDispatcher
    {
        private ApplicationDbContext _Context { get; }

        public QueryDispatcher(ApplicationDbContext context)
        {
            _Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IResult Dispatch(IQuery query)
        {
            //var _handler = _Context.Resolve<IQueryHandler<TParameter, TResult>>();
            //return _handler.Retrieve(query);

            if (query == null) throw new ArgumentNullException(nameof(query));

            switch (query)
            {
                case GetBooksQuery qry:
                    GetBooksQueryHandler handler = new GetBooksQueryHandler(_Context);
                    return handler.Retrieve(qry);
                default:  // if the value is not recognized
                    throw new ArgumentException(nameof(query));
            }
        }
    }
}