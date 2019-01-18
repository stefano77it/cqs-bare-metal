using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpFunctionalExtensions;
using ProjX.SimulationEngine.Api.Caller.v1;
using ProjX.SimulationEngine.Api.Contracts.v1;
using ProjX.SimulationEngine;

namespace ProjX.SimulationEngine.Tests
{
    [TestClass]
    public class QueryDispatcher_Tests
    {
        [TestMethod]
        public void QueryDispatcher_TypeError__Test()
        {
            #region preparation
            ApplicationContext _Context = new ApplicationContext();
            QueryDispatcher _QueryDispatcher = new QueryDispatcher();

            GetBooksQuery query = new GetBooksQuery(true);   // init query
            #endregion

            #region test error
            Assert.ThrowsException<InvalidOperationException>(
                () => _QueryDispatcher.Dispatch<GetBooksQueryResult, WrongClass>(_Context, query)
                );  // call the dispatcher with the wrong class
            #endregion

            #region test success
            _QueryDispatcher.Dispatch<GetBooksQueryResult, GetBooksQueryError>(_Context, query);  // call the dispatcher with the right class
            #endregion
        }

        private class WrongClass
        { }
    }
}
