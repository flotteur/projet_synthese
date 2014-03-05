using Data_synthese;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TEST_Data_Synthese
{
    
    
    /// <summary>
    ///This is a test class for oiseauTest and is intended
    ///to contain all oiseauTest Unit Tests
    ///</summary>
    [TestClass()]
    public class oiseauTest
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
        ///A test for oiseau Constructor
        ///</summary>
        [TestMethod()]
        public void oiseauConstructorTest()
        {
            oiseau target = new oiseau();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Description
        ///</summary>
        [TestMethod()]
        public void DescriptionTest()
        {
            oiseau target = new oiseau(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Description = expected;
            actual = target.Description;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Espece
        ///</summary>
        [TestMethod()]
        public void EspeceTest()
        {
            oiseau target = new oiseau(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Espece = expected;
            actual = target.Espece;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        
        /// <summary>
        ///A test for Id
        ///</summary>
        [TestMethod()]
        public void IdTest()
        {
            oiseau target = new oiseau(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.Id = expected;
            actual = target.Id;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for alertes
        ///</summary>
        [TestMethod()]
        public void alertesTest()
        {
            oiseau target = new oiseau(); // TODO: Initialize to an appropriate value
            ICollection<alerte> expected = null; // TODO: Initialize to an appropriate value
            ICollection<alerte> actual;
            target.alertes = expected;
            actual = target.alertes;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for crioiseaux
        ///</summary>
        [TestMethod()]
        public void crioiseauxTest()
        {
            oiseau target = new oiseau(); // TODO: Initialize to an appropriate value
            ICollection<crioiseau> expected = null; // TODO: Initialize to an appropriate value
            ICollection<crioiseau> actual;
            target.crioiseaux = expected;
            actual = target.crioiseaux;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for observations
        ///</summary>
        [TestMethod()]
        public void observationsTest()
        {
            oiseau target = new oiseau(); // TODO: Initialize to an appropriate value
            ICollection<observation> expected = null; // TODO: Initialize to an appropriate value
            ICollection<observation> actual;
            target.observations = expected;
            actual = target.observations;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for photos
        ///</summary>
        [TestMethod()]
        public void photosTest()
        {
            oiseau target = new oiseau(); // TODO: Initialize to an appropriate value
            ICollection<photo> expected = null; // TODO: Initialize to an appropriate value
            ICollection<photo> actual;
            target.photos = expected;
            actual = target.photos;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
