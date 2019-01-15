namespace Cqs.SampleApp.Core
{
    public class SaveBookCommandHandler : CommandHandler<SaveBookCommand, SaveBookCommandResult>
    {
        public SaveBookCommandHandler(ApplicationDbContext context) : base(context)
        {
        }

        protected override SaveBookCommandResult DoHandle(SaveBookCommand request)
        {
            var _response = new SaveBookCommandResult();

            //add the book
            ApplicationDbContext.Books.Add(request.Book);

            return _response;
        }
    }
}