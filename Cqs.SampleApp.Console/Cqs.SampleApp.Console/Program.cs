using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cqs.SampleApp.Core;
using log4net;

namespace Cqs.SampleApp.Console
{
    internal class Program
    {
        private static readonly ILog _Log = LogManager.GetLogger(typeof(Program).Name);

        private static void Main(string[] args)
        {

            _Log.Info("Bootsrapping application..");

            ApplicationDbContext _context = new ApplicationDbContext();

            _Log.Info("WithCqs..");
            WithCqs(_context);

            _Log.Info("WithoutCqs..");
            WithoutCqs(_context);

            System.Console.ReadLine();
        }

        private static void WithCqs(ApplicationDbContext _context)
        {
            QueryDispatcher _queryDispatcher = new QueryDispatcher(_context);

            CommandDispatcher _commandDispatcher = new CommandDispatcher(_context);

            //add new book
            SaveBookCommandResult cmdResult = ResultConvert<SaveBookCommandResult>(_commandDispatcher.Dispatch(new SaveBookCommand()
            {
                Book = new Book()
                {
                    Title = "C# in Depth#2",
                    Authors = "Jon Skeet#2",
                    InMyPossession = false,
                    DatePublished = new DateTime(2013, 07, 01)
                }
            }));

            // read all books + print them
            GetBooksQueryResult _response = ResultConvert<GetBooksQueryResult>(_queryDispatcher.Dispatch(new GetBooksQuery()));
            _Log.Info("Retrieving all books the CQS Way..");
            foreach (var _book in _response.Books)
            { _Log.InfoFormat("Title: {0}, Authors: {1}, InMyPossession: {2}", _book.Title, _book.Authors, _book.InMyPossession); }

            //edit first book
            var _bookToEdit = _response.Books.First();
            _bookToEdit.InMyPossession = !_bookToEdit.InMyPossession;
            cmdResult = ResultConvert<SaveBookCommandResult>(_commandDispatcher.Dispatch(new SaveBookCommand()
            {
                Book = new Book()
                {
                    Title = "C# in Depth#2",
                    Authors = "Jon Skeet#2",
                    InMyPossession = false,
                    DatePublished = new DateTime(2013, 07, 01)
                }
            }));

            // read all books + print them
            _response = ResultConvert<GetBooksQueryResult>(_queryDispatcher.Dispatch(new GetBooksQuery()));
            foreach (var _book in _response.Books)
            { _Log.InfoFormat("Title: {0}, Authors: {1}, InMyPossession: {2}", _book.Title, _book.Authors, _book.InMyPossession); }

            // local function to intercept mismatch from the server reply and the expected type
            TResult ResultConvert<TResult>(object result)
            {
                if (!(result is TResult)) throw new InvalidOperationException("server call error, return not of the expected type");
                return (TResult)result;
            }
        }


        private static void WithoutCqs(ApplicationDbContext _context)
        {
            //save some books if there are none in the database
            if (!_context.Books.Any())
            {
                _context.Books.Add(new Book()
                {
                    Authors = "Andrew Hunt, David Thomas",
                    Title = "The Pragmatic Programmer",
                    InMyPossession = true,
                    DatePublished = new DateTime(1999, 10, 20),
                });

                _context.Books.Add(new Book()
                {
                    Authors = "Robert C. Martin",
                    Title = "The Clean Coder: A Code of Conduct for Professional Programmers",
                    InMyPossession = false,
                    DatePublished = new DateTime(2011, 05, 13),
                });

                _Log.Info("Books saved..");
            }

            _Log.Info("Retrieving all books the NON CQS Way..");

            foreach (var _book in _context.Books)
            {
                _Log.InfoFormat("Title: {0}, Authors: {1}, InMyPossession: {2}", _book.Title, _book.Authors, _book.InMyPossession);
            }
        }
    }
}
