using Data_synthese;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TEST_Data_Synthese
{
    
    
    /// <summary>
    ///This is a test class for alerteTest and is intended
    ///to contain all alerteTest Unit Tests
    ///</summary>
    [TestClass()]
    public class alerteTest
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
        ///A test for alerte Constructor
        ///</summary>
        [TestMethod()]
        public void alerteConstructorTest()
        {
            alerte target = new alerte();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for IDObservation
        ///</summary>
        [TestMethod()]
        public void IDObservationTest()
        {
            alerte target = new alerte(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.IDObservation = expected;
            actual = target.IDObservation;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IDUsager
        ///</summary>
        [TestMethod()]
        public void IDUsagerTest()
        {
            alerte target = new alerte(); // TODO: Initialize to an appropriate value
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
            alerte target = new alerte(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.Id = expected;
            actual = target.Id;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OiseauId
        ///</summary>
        [TestMethod()]
        public void OiseauIdTest()
        {
            alerte target = new alerte(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.OiseauId = expected;
            actual = target.OiseauId;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for alertesusagers
        ///</summary>
        [TestMethod()]
        public void alertesusagersTest()
        {
            alerte target = new alerte(); // TODO: Initialize to an appropriate value
            alertesusager expected = null; // TODO: Initialize to an appropriate value
            alertesusager actual;
            target.alertesusagers = expected;
            actual = target.alertesusagers;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for oiseaux
        ///</summary>
        [TestMethod()]
        public void oiseauxTest()
        {
            alerte target = new alerte(); // TODO: Initialize to an appropriate value
            oiseau expected = null; // TODO: Initialize to an appropriate value
            oiseau actual;
            target.oiseaux = expected;
            actual = target.oiseaux;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
