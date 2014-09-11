using System;
using System.Security.Principal;
using Iris.Fx.Domain;
using Iris.WinAuthentication.Contract.Agent;
using Iris.WinAuthentication.Contract.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iris.WinAuthentication.Contract.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class WinAuthenticationTestFixture
    {
        public WinAuthenticationTestFixture()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

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
        public void Try_GetMyIrisSession()
        {
            try
            { 
                IWinAuthenticationAgent agt = WinAuthenticationAgentFactory.CreateAgent();
                IrisSession sess = agt.AuthenticateUserCredentials();
                Assert.AreNotEqual(null, sess);
                Assert.AreEqual(sess.Username, WindowsIdentity.GetCurrent().Name);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
