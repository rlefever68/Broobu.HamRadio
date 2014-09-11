using Iris.MonitorSession.Contract.Agent;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iris.MonitorSession.Contract.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class MonitorSessionTestFixture
    {

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Try_GetSessions()
        {
            var lst = MonitorSessionAgentFactory
                .CreateAgent()
                .GetSessions();
            Assert.IsTrue(lst.Length >= 0);
        }
    }
}
