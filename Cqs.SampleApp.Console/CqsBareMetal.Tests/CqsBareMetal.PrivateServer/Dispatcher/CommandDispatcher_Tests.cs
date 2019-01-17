using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpFunctionalExtensions;
using CqsBareMetal.Apis.Server.v1;
using CqsBareMetal.Apis.v1;
using CqsBareMetal.Server;

namespace CqsBareMetal.Tests
{
    [TestClass]
    public class CommandDispatcher_Tests
    {
        [TestMethod]
        public void CommandDispatcher_TypeError__Test()
        {
            #region preparation
            ApplicationContext _Context = new ApplicationContext();
            CommandDispatcher _CommandDispatcher = new CommandDispatcher();

            SaveBookCommand command = new SaveBookCommand("titolo", true);   // init command
            #endregion

            #region test error
            Assert.ThrowsException<InvalidOperationException>(
                () => _CommandDispatcher.Dispatch<SaveBookCommandResult, WrongClass>(_Context, command)
                );  // call the dispatcher with the wrong class
            #endregion

            #region test success
            _CommandDispatcher.Dispatch<SaveBookCommandResult, SaveBookCommandError>(_Context, command);  // call the dispatcher with the right class
            #endregion
        }

        private class WrongClass
        { }
    }
}
