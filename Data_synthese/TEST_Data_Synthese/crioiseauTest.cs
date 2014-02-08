using Data_synthese;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TEST_Data_Synthese
{
    
    
    /// <summary>
    ///This is a test class for crioiseauTest and is intended
    ///to contain all crioiseauTest Unit Tests
    ///</summary>
    [TestClass()]
    public class crioiseauTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for crioiseau Constructor
        ///</summary>
        [TestMethod()]
        public void crioiseauConstructorTest()
        {
            crioiseau target = new crioiseau();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Description
        ///</summary>
        [TestMethod()]
        public void DescriptionTest()
        {
            crioiseau target = new crioiseau(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Description = expected;
            actual = target.Description;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IDOiseau
        ///</summary>
        [TestMethod()]
        public void IDOiseauTest()
        {
            crioiseau target = new crioiseau(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.IDOiseau = expected;
            actual = target.IDOiseau;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Id
        ///</summary>
        [TestMethod()]
        public void IdTest()
        {
            crioiseau target = new crioiseau(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.Id = expected;
            actual = target.Id;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Son
        ///</summary>
        [TestMethod()]
        public void SonTest()
        {
            crioiseau target = new crioiseau(); // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            target.Son = expected;
            actual = target.Son;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for oiseaux
        ///</summary>
        [TestMethod()]
        public void oiseauxTest()
        {
            crioiseau target = new crioiseau(); // TODO: Initialize to an appropriate value
            oiseau expected = null; // TODO: Initialize to an appropriate value
            oiseau actual;
            target.oiseaux = expected;
            actual = target.oiseaux;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
