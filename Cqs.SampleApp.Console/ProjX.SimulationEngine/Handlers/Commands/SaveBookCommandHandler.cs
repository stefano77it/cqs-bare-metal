using System;
using ProjX.SimulationEngine.Api.Contracts.v1;
using CSharpFunctionalExtensions;

namespace ProjX.SimulationEngine
{
    public class SaveBookCommandHandler : CommandHandler_Base<SaveBookCommand, SaveBookCommandResult, SaveBookCommandError>
    {
        public SaveBookCommandHandler(ApplicationContext context) : base(context)
        { }

        // protected method, callable only through base class public methods
        protected override Result<SaveBookCommandResult, SaveBookCommandError>
            DoHandle(SaveBookCommand request)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));  // can't be null

            var _response = new SaveBookCommandResult();

            //add the book
            Book book = new Book(request.Title, request.InMyPossession);
            _Context.Books.Add(book);

            // return
            return Result.Ok<SaveBookCommandResult, SaveBookCommandError>(_response);
        }

        // protected method, callable only through base class public methods
        protected override Result<SaveBookCommandResult, SaveBookCommandError> InternalServerError(string errorDetail)
        {
            return Result.Fail<SaveBookCommandResult, SaveBookCommandError>
               (SaveBookCommandError.Set_InternalServerError(errorDetail));
        }
    }
}
