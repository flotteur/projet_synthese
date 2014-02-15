using Data_synthese;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TEST_Data_Synthese
{
    
    
    /// <summary>
    ///This is a test class for observationTest and is intended
    ///to contain all observationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class observationTest
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
        ///A test for observation Constructor
        ///</summary>
        [TestMethod()]
        public void observationConstructorTest()
        {
            observation target = new observation();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DateObservation
        ///</summary>
        [TestMethod()]
        public void DateObservationTest()
        {
            observation target = new observation(); // TODO: Initialize to an appropriate value
            DateTime expected = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime actual;
            target.DateObservation = expected;
            actual = target.DateObservation;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IDOiseau
        ///</summary>
        [TestMethod()]
        public void IDOiseauTest()
        {
            observation target = new observation(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.IDOiseau = expected;
            actual = target.IDOiseau;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IDUsager
        ///</summary>
        [TestMethod()]
        public void IDUsagerTest()
        {
            observation target = new observation(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.IDUsager = expected;
            actual = target.IDUsager;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Id
        ///</summary>
        [TestMethod()]
        public void IdTest()
        {
            observation target = new observation(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.Id = expected;
            actual = target.Id;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

              
        /// <summary>
        ///A test for oiseaux
        ///</summary>
        [TestMethod()]
        public void oiseauxTest()
        {
            observation target = new observation(); // TODO: Initialize to an appropriate value
            oiseau expected = null; // TODO: Initialize to an appropriate value
            oiseau actual;
            target.oiseaux = expected;
            actual = target.oiseaux;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

       
       
        /// <summary>
        ///A test for usagers
        ///</summary>
        [TestMethod()]
        public void usagersTest()
        {
            observation target = new observation(); // TODO: Initialize to an appropriate value
            usager expected = null; // TODO: Initialize to an appropriate value
            usager actual;
            target.usagers = expected;
            actual = target.usagers;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
