using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpFunctionalExtensions;
using ProjX.SimulationEngine.Api.Caller.v1;
using ProjX.SimulationEngine.Api.Contracts.v1;
using ProjX.SimulationEngine;

namespace ProjX.SimulationEngine.Tests
{
    [TestClass]
    public class QueryHandler_Tests
    {
        [TestMethod]
        public void QueryHandler_Exception_Test()
        {
            #region preparation
            ApplicationContext _Context = new ApplicationContext();
            string errorType = GetBooksQueryError.Set_InternalServerError("").ErrorType;
            string errorDetail_part = "Value cannot be null";
            #endregion

            #region test error
            Result<GetBooksQueryResult, GetBooksQueryError> result =
                new GetBooksQueryHandler(_Context).Handle(null);

            Assert.AreEqual(errorType, result.Error.ErrorType);
            Assert.IsTrue(result.Error.ErrorDetail.Contains(errorDetail_part));
            #endregion
        }
    }
}
