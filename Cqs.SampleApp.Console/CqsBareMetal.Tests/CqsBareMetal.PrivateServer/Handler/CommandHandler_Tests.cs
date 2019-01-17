using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpFunctionalExtensions;
using CqsBareMetal.Apis.Server.v1;
using CqsBareMetal.Apis.v1;
using CqsBareMetal.Server;

namespace CqsBareMetal.Tests
{
    [TestClass]
    public class CommandHandler_Tests
    {
        [TestMethod]
        public void CommandHandler_Exception_Test()
        {
            #region preparation
            ApplicationContext _Context = new ApplicationContext();
            string errorType = SaveBookCommandError.Set_InternalServerError("").ErrorType;
            string errorDetail_part = "Object reference not set to an instance of an object";
            #endregion

            #region test error
            Result<SaveBookCommandResult, SaveBookCommandError> result =
                new SaveBookCommandHandler(_Context).Handle(null);

            Assert.AreEqual(errorType, result.Error.ErrorType);
            Assert.IsTrue(result.Error.ErrorDetail.Contains(errorDetail_part));
            #endregion
        }

        [TestMethod]
        public void CommandHandler_InterceptCommandExecuted2Times_Test()
        {
            #region preparation
            ApplicationContext _Context = new ApplicationContext();
            string errorType = SaveBookCommandError.Set_InternalServerError("").ErrorType;
            string errorDetail_part = "command already processed";
            #endregion

            #region test error
            SaveBookCommand command = new SaveBookCommand("titolo1", true);   // command to execute 2 times
            Result<SaveBookCommandResult, SaveBookCommandError> result =
                new SaveBookCommandHandler(_Context).Handle(command);  // first execution, success
            Assert.IsTrue(result.IsSuccess);

            result = new SaveBookCommandHandler(_Context).Handle(command);  // second execution, failure

            Assert.AreEqual(errorType, result.Error.ErrorType);
            Assert.IsTrue(result.Error.ErrorDetail.Contains(errorDetail_part));
            #endregion
        }
    }
}
