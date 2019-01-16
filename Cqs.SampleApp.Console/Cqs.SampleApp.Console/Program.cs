using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CqsBareMetal.Apis.Server.v1;
using CqsBareMetal.Apis.v1;
using log4net;
using CSharpFunctionalExtensions;

namespace CqsBareMetal.Console
{
    internal class Program
    {
        private static readonly ILog _Log = LogManager.GetLogger(typeof(Program).Name);

        private static void Main(string[] args)
        {
            _Log.Info("Bootsrapping application..");

            ApiServer _server = new ApiServer();

            _Log.Info("WithCqs..");

            // init command and query results
            Result<SaveBookCommandResult, SaveBookCommandError> cmdResult;
            Result<GetBooksQueryResult, GetBooksQueryError> queryResult;

            //add new book
            cmdResult = _server.SaveBook(new SaveBookCommand("C# in Depth#1", false));
            cmdResult = _server.SaveBook(new SaveBookCommand("C# in Depth#2", true));
            PrintCommand("Add 2 books", cmdResult);

            // read all books + print them
            queryResult = _server.GetBooks(new GetBooksQuery(false));
            PrintQuery("All books query", queryResult);

            //add another book
            cmdResult = _server.SaveBook(new SaveBookCommand("C# in Depth#3", true));
            PrintCommand("Add 1 book", cmdResult);

            // read filtered books + print them
            queryResult = _server.GetBooks(new GetBooksQuery(true));
            PrintQuery("Filtered books query", queryResult);

            System.Console.ReadLine();

            void PrintCommand(string msg, Result<SaveBookCommandResult, SaveBookCommandError> command)
            {
                _Log.Info("Executing command the CQS Way..");
                if (command.IsFailure)
                { _Log.InfoFormat($"{msg} Error: {command.Error}"); }
                else
                { _Log.InfoFormat($"{msg} Success"); }
            }

            void PrintQuery(string msg, Result<GetBooksQueryResult, GetBooksQueryError> query)
            {
                _Log.Info("Retrieving all books the CQS Way..");
                if (query.IsFailure)
                { _Log.InfoFormat($"{msg} Error: {query.Error}"); }
                else
                {
                    _Log.InfoFormat($"{msg} Success");
                    foreach (var _book in query.Value.Books)
                    {
                        _Log.InfoFormat($"Title: {_book.Title}, InMyPossession: {_book.InMyPossession}");
                    }
                }
            }
        }
    }
}
