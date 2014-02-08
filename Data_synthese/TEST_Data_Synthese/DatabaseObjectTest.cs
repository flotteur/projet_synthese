using Data_synthese.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entites_Synthese;
using Data_synthese;

namespace TEST_Data_Synthese
{
    
    
    /// <summary>
    ///This is a test class for DatabaseObjectTest and is intended
    ///to contain all DatabaseObjectTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DatabaseObjectTest
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
        ///A test for DatabaseObject Constructor
        ///</summary>
        [TestMethod()]
        public void DatabaseObjectConstructorTest()
        {
            DatabaseObject target = new DatabaseObject();
            Usager_Entite user =  target.InsertUsager("Raymond Ferland",
                "RFerland",
                "Password",
                true,
                "rferland@diq.ca");
            Assert.IsTrue(user != null); 
        }

        /// <summary>
        ///A test for ClearDatabase
        ///</summary>
        [TestMethod()]
        public void ClearDatabaseTest()
        {
            DatabaseObject target = new DatabaseObject(); // TODO: Initialize to an appropriate value
            target.ClearDatabase();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DeleteUsager
        ///</summary>
        [TestMethod()]
        public void DeleteUsagerTest()
        {
            DatabaseObject target = new DatabaseObject(); // TODO: Initialize to an appropriate value
            int pUsagerID = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.DeleteUsager(pUsagerID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Data_synthese.dll")]
        public void DisposeTest()
        {
            DatabaseObject_Accessor target = new DatabaseObject_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        public void DisposeTest1()
        {
            DatabaseObject target = new DatabaseObject(); // TODO: Initialize to an appropriate value
            target.Dispose();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Finalize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Data_synthese.dll")]
        public void FinalizeTest()
        {
            DatabaseObject_Accessor target = new DatabaseObject_Accessor(); // TODO: Initialize to an appropriate value
            target.Finalize();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetUsager
        ///</summary>
        [TestMethod()]
        public void GetUsagerTest()
        {
            DatabaseObject target = new DatabaseObject(); // TODO: Initialize to an appropriate value
            int PID = 0; // TODO: Initialize to an appropriate value
            Usager_Entite expected = null; // TODO: Initialize to an appropriate value
            Usager_Entite actual;
            actual = target.GetUsager(PID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetUsager
        ///</summary>
        [TestMethod()]
        public void GetUsagerTest1()
        {
            DatabaseObject target = new DatabaseObject(); // TODO: Initialize to an appropriate value
            string pUser = string.Empty; // TODO: Initialize to an appropriate value
            Usager_Entite expected = null; // TODO: Initialize to an appropriate value
            Usager_Entite actual;
            actual = target.GetUsager(pUser);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InsertUsager
        ///</summary>
        [TestMethod()]
        public void InsertUsagerTest()
        {
            DatabaseObject target = new DatabaseObject(); // TODO: Initialize to an appropriate value
            string pNom = string.Empty; // TODO: Initialize to an appropriate value
            string pUsername = string.Empty; // TODO: Initialize to an appropriate value
            string pPassword = string.Empty; // TODO: Initialize to an appropriate value
            bool pEstAdministrateur = false; // TODO: Initialize to an appropriate value
            string pCourriel = string.Empty; // TODO: Initialize to an appropriate value
            Usager_Entite expected = null; // TODO: Initialize to an appropriate value
            Usager_Entite actual;
            actual = target.InsertUsager(pNom, pUsername, pPassword, pEstAdministrateur, pCourriel);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SaveChanges
        ///</summary>
        [TestMethod()]
        public void SaveChangesTest()
        {
            DatabaseObject target = new DatabaseObject(); // TODO: Initialize to an appropriate value
            target.SaveChanges();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Crypteur
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Data_synthese.dll")]
        public void CrypteurTest()
        {
            DatabaseObject_Accessor target = new DatabaseObject_Accessor(); // TODO: Initialize to an appropriate value
            Encription expected = null; // TODO: Initialize to an appropriate value
            Encription actual;
            target.Crypteur = expected;
            actual = target.Crypteur;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GlobalKey
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Data_synthese.dll")]
        public void GlobalKeyTest()
        {
            DatabaseObject_Accessor target = new DatabaseObject_Accessor(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GlobalKey;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for dbContext
        ///</summary>
        [TestMethod()]
        public void dbContextTest()
        {
            DatabaseObject target = new DatabaseObject(); // TODO: Initialize to an appropriate value
            synthese_dbEntities expected = null; // TODO: Initialize to an appropriate value
            synthese_dbEntities actual;
            target.dbContext = expected;
            actual = target.dbContext;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
