using Data_synthese;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TEST_Data_Synthese
{
    
    
    /// <summary>
    ///This is a test class for usagerTest and is intended
    ///to contain all usagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class usagerTest
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
        ///A test for usager Constructor
        ///</summary>
        [TestMethod()]
        public void usagerConstructorTest()
        {
            usager target = new usager();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Administrateur
        ///</summary>
        [TestMethod()]
        public void AdministrateurTest()
        {
            usager target = new usager(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Administrateur = expected;
            actual = target.Administrateur;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Courriel
        ///</summary>
        [TestMethod()]
        public void CourrielTest()
        {
            usager target = new usager(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Courriel = expected;
            actual = target.Courriel;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

       
        /// <summary>
        ///A test for Id
        ///</summary>
        [TestMethod()]
        public void IdTest()
        {
            usager target = new usager(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.Id = expected;
            actual = target.Id;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

       
        /// <summary>
        ///A test for MotPasse
        ///</summary>
        [TestMethod()]
        public void MotPasseTest()
        {
            usager target = new usager(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.MotPasse = expected;
            actual = target.MotPasse;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NomUsager
        ///</summary>
        [TestMethod()]
        public void NomUsagerTest()
        {
            usager target = new usager(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.NomUsager = expected;
            actual = target.NomUsager;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

             

        /// <summary>
        ///A test for observations
        ///</summary>
        [TestMethod()]
        public void observationsTest()
        {
            usager target = new usager(); // TODO: Initialize to an appropriate value
            ICollection<observation> expected = null; // TODO: Initialize to an appropriate value
            ICollection<observation> actual;
            target.observations = expected;
            actual = target.observations;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
