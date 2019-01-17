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
            ApiServer2 _ServerType2_UsingDirectMethodCalls = new ApiServer2();
            ApiServer _ServerType1_UsingDispatcher = new ApiServer();

            ServerCall(_ServerType2_UsingDirectMethodCalls);  // <-- prefer direct calls; handlers are shorter and clearer
            //ServerCall(_ServerType1_UsingDispatcher);  // <-- with dispatcher handlers are longer and less clear
        }

        private static void ServerCall(IApiServer _server)
        {
            _Log.Info("Bootsrapping application..");

            _Log.Info("WithCqs..");

            // init command and query results
            Result<SaveBookCommandResult, SaveBookCommandError> cmdResult;
            Result<GetBooksQueryResult, GetBooksQueryError> queryResult;

            //add new book
            cmdResult = _server.SaveBook(new SaveBookCommand("C# in Depth#1", false));
            PrintCommand("Add 1 book", cmdResult);
            cmdResult = _server.SaveBook(new SaveBookCommand("C# in Depth#2", true));
            PrintCommand("Add 1 book", cmdResult);

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
        }
        private static void PrintCommand(string msg, Result<SaveBookCommandResult, SaveBookCommandError> command)
        {
            if (command.IsFailure)
            { _Log.InfoFormat($"{msg} Error: {command.Error.Value}"); }
            else
            { _Log.InfoFormat($"{msg} Success"); }
        }

        private static void PrintQuery(string msg, Result<GetBooksQueryResult, GetBooksQueryError> query)
        {
            if (query.IsFailure)
            { _Log.InfoFormat($"{msg} Error: {query.Error.Value}"); }
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
