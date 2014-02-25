using BO_Synthese;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entites_Synthese;

namespace TEST_BO_Synthese
{
    
    
    /// <summary>
    ///This is a test class for BOTest and is intended
    ///to contain all BOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BOTest
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
        ///A test for BO Constructor
        ///</summary>
        [TestMethod()]
        public void BOConstructorTest()
        {
            BO target = new BO();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ClearDatabase
        ///</summary>
        [TestMethod()]
        public void ClearDatabaseTest()
        {
            BO target = new BO(); // TODO: Initialize to an appropriate value
            target.ClearDatabase();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CreerUsager OK 2014-02-16
        /// S'assurer que l'usager ne peut être créé deux fois
        ///</summary>
        [TestMethod()]
        public void CreerUsagerTest()
        {
            
            BO BusinessObject = new BO(); // 
            string nom = "Raymond Ferland";
            string nomUsager = "rferland";
            string motPasse = "MotDePasse";
            string courriel = "rferland@diq.ca";

            
            Usager_Entite pUsager = new Usager_Entite
            {
                Nom = nom,
                NomUsager = nomUsager,
                MotDePasse = motPasse,
                Courriel = courriel,
                EstAdministrateur = true
            };

            // On commence par supprimer l'usager s'il existe
           BusinessObject.SupprimerUsager(pUsager.NomUsager);
            BusinessObject.SaveChanges();

            Usager_Entite actual = BusinessObject.CreerUsager(pUsager);

            actual = BusinessObject.ObtenirUsager(actual.ID);                    

            Assert.IsNotNull(actual, "CreerUsager a retourné NULL");
            Assert.IsTrue(string.Compare(actual.Nom, nom) == 0);
            Assert.IsTrue(string.Compare(actual.NomUsager, nomUsager) == 0);
            Assert.IsTrue(string.Compare(actual.MotDePasse, motPasse) != 0); // Le mot de passe est hashe
            Assert.IsTrue(string.Compare(actual.Courriel, courriel) == 0);
            Assert.IsTrue(actual.ID > 0);

            // Pas deux fois le même nomUsager
            pUsager.Courriel = "raubindiq.ca";
            actual = BusinessObject.CreerUsager(pUsager);
            
            Assert.IsTrue(!string.IsNullOrEmpty(  actual.MessageErreur), "CreerUsager on peut insérer deux fois le même username");
            

            // Pas deux fois le même courriel
            pUsager.Courriel = "rferland@diq.ca";
            pUsager.NomUsager = "rferland";
            actual = BusinessObject.CreerUsager(pUsager);

            Assert.IsTrue(!string.IsNullOrEmpty(actual.MessageErreur), "CreerUsager on peut insérer deux fois le même courriel");
            

        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        public void DisposeTest()
        {
            BO target = new BO(); // TODO: Initialize to an appropriate value
            target.Dispose();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("BO_Synthese.dll")]
        public void DisposeTest1()
        {
            BO_Accessor target = new BO_Accessor(); // TODO: Initialize to an appropriate value
            bool pDisposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(pDisposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Getusager
        ///</summary>
        [TestMethod()]
        public void Getusager()
        {
            BO BusinessObject = new BO(); // 
            string nom = "Raymond Ferland";
            string nomUsager = "rferland";
            string motPasse = "MotDePasse";
            string courriel = "rferland@diq.ca";


            Usager_Entite pUsager = new Usager_Entite
            {
                Nom = nom,
                NomUsager = nomUsager,
                MotDePasse = motPasse,
                Courriel = courriel,
                EstAdministrateur = true
            };

            // On commence par supprimer l'usager s'il existe
            BusinessObject.SupprimerUsager(pUsager.NomUsager);
            BusinessObject.SaveChanges();

            Usager_Entite actual = BusinessObject.CreerUsager(pUsager);

            actual = BusinessObject.ObtenirUsager(actual.ID);

            Assert.IsNotNull(actual, "CreerUsager a retourné NULL");
            Assert.IsTrue(string.Compare(actual.Nom, nom) == 0);
            Assert.IsTrue(string.Compare(actual.NomUsager, nomUsager) == 0);
            Assert.IsTrue(string.Compare(actual.MotDePasse, motPasse) != 0); // Le mot de passe est hashe
            Assert.IsTrue(string.Compare(actual.Courriel, courriel) == 0);
            Assert.IsTrue(actual.ID > 0);
        }

        /// <summary>
        ///A test for Login
        ///</summary>
        [TestMethod()]
        public void LoginTest()
        {
            BO target = new BO(); // TODO: Initialize to an appropriate value
            string pUser = string.Empty; // TODO: Initialize to an appropriate value
            string pPassword = string.Empty; // TODO: Initialize to an appropriate value
            Usager_Entite expected = null; // TODO: Initialize to an appropriate value
            Usager_Entite actual;
            actual = target.Login(pUser, pPassword);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SaveChanges
        ///</summary>
        [TestMethod()]
        public void SaveChangesTest()
        {
            BO target = new BO(); // TODO: Initialize to an appropriate value
            target.SaveChanges();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
