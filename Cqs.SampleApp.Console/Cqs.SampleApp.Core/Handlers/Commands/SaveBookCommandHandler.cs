using System;
using CqsBareMetal.Apis.v1;
using CSharpFunctionalExtensions;

namespace CqsBareMetal.Server
{
    internal class SaveBookCommandHandler : ICommandHandler
    {
        internal SaveBookCommandHandler()
        { }

        internal Result<SaveBookCommandResult, SaveBookCommandError> 
            Handle(ApplicationDbContext context, SaveBookCommand request)
        {
            if (context is null) throw new ArgumentNullException(nameof(context));  // can't be null
            if (request is null) throw new ArgumentNullException(nameof(request));  // can't be null

            var _response = new SaveBookCommandResult();

            //add the book
            Book book = new Book(request.Title, request.InMyPossession);
            context.Books.Add(book);

            // return
            return Result.Ok<SaveBookCommandResult, SaveBookCommandError>(_response);
        }
    }
}
