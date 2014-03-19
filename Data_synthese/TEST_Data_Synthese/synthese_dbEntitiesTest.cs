using Data_synthese;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity;
using Data_synthese;

namespace TEST_Data_Synthese
{
    
    
    /// <summary>
    ///This is a test class for synthese_dbEntitiesTest and is intended
    ///to contain all synthese_dbEntitiesTest Unit Tests
    ///</summary>
    [TestClass()]
    public class synthese_dbEntitiesTest
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
        ///A test for synthese_dbEntities Constructor
        ///</summary>
        [TestMethod()]
        public void synthese_dbEntitiesConstructorTest()
        {
            synthese_dbEntities target = new synthese_dbEntities();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for OnModelCreating
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Data_synthese.dll")]
        public void OnModelCreatingTest()
        {
            synthese_dbEntities_Accessor target = new synthese_dbEntities_Accessor(); // TODO: Initialize to an appropriate value
            DbModelBuilder modelBuilder = null; // TODO: Initialize to an appropriate value
            target.OnModelCreating(modelBuilder);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for alerte
        ///</summary>
        [TestMethod()]
        public void alerteTest()
        {
            synthese_dbEntities target = new synthese_dbEntities(); // TODO: Initialize to an appropriate value
            DbSet<alerte> expected = null; // TODO: Initialize to an appropriate value
            DbSet<alerte> actual;
            target.alerte = expected;
            actual = target.alerte;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

       
        /// <summary>
        ///A test for crioiseau
        ///</summary>
        [TestMethod()]
        public void crioiseauTest()
        {
            synthese_dbEntities target = new synthese_dbEntities(); // TODO: Initialize to an appropriate value
            DbSet<crioiseau> expected = null; // TODO: Initialize to an appropriate value
            DbSet<crioiseau> actual;
            target.crioiseau = expected;
            actual = target.crioiseau;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for message
        ///</summary>
        [TestMethod()]
        public void messageTest()
        {
            synthese_dbEntities target = new synthese_dbEntities(); // TODO: Initialize to an appropriate value
            DbSet<message> expected = null; // TODO: Initialize to an appropriate value
            DbSet<message> actual;
            target.message = expected;
            actual = target.message;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for observation
        ///</summary>
        [TestMethod()]
        public void observationTest()
        {
            synthese_dbEntities target = new synthese_dbEntities(); // TODO: Initialize to an appropriate value
            DbSet<Observation> expected = null; // TODO: Initialize to an appropriate value
            DbSet<Observation> actual;
            target.observation = expected;
            actual = target.observation;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for oiseau
        ///</summary>
        [TestMethod()]
        public void oiseauTest()
        {
            synthese_dbEntities target = new synthese_dbEntities(); // TODO: Initialize to an appropriate value
            DbSet<oiseau> expected = null; // TODO: Initialize to an appropriate value
            DbSet<oiseau> actual;
            target.oiseau = expected;
            actual = target.oiseau;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for photo
        ///</summary>
        [TestMethod()]
        public void photoTest()
        {
            synthese_dbEntities target = new synthese_dbEntities(); // TODO: Initialize to an appropriate value
            DbSet<photo> expected = null; // TODO: Initialize to an appropriate value
            DbSet<photo> actual;
            target.photo = expected;
            actual = target.photo;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for photoobservation
        ///</summary>
        [TestMethod()]
        public void photoobservationTest()
        {
            synthese_dbEntities target = new synthese_dbEntities(); // TODO: Initialize to an appropriate value
            DbSet<photoobservation> expected = null; // TODO: Initialize to an appropriate value
            DbSet<photoobservation> actual;
            target.photoobservation = expected;
            actual = target.photoobservation;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for sonobservation
        ///</summary>
        [TestMethod()]
        public void sonobservationTest()
        {
            synthese_dbEntities target = new synthese_dbEntities(); // TODO: Initialize to an appropriate value
            DbSet<sonobservation> expected = null; // TODO: Initialize to an appropriate value
            DbSet<sonobservation> actual;
            target.sonobservation = expected;
            actual = target.sonobservation;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for usager
        ///</summary>
        [TestMethod()]
        public void usagerTest()
        {
            synthese_dbEntities target = new synthese_dbEntities(); // TODO: Initialize to an appropriate value
            DbSet<usager> expected = null; // TODO: Initialize to an appropriate value
            DbSet<usager> actual;
            target.usager = expected;
            actual = target.usager;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
