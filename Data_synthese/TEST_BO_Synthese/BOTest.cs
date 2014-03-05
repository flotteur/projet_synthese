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

        private static Usager_Entite _CreerUsager(out string nom,
            out string nomUsager,
            out string motPasse,
            out string courriel)
        {
            nom = "Raymond Ferland";
            nomUsager = "rferland";
            motPasse = "MotDePasse";
            courriel = "rferland@diq.ca";


            Usager_Entite usager = new Usager_Entite
            {
                Nom = nom,
                NomUsager = nomUsager,
                MotDePasse = motPasse,
                Courriel = courriel,
                EstAdministrateur = true
            };
            return usager;
        }

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
            string nom ;
            string nomUsager ;
            string motPasse ;
            string courriel ;

            
            Usager_Entite pUsager = _CreerUsager( out nom, out nomUsager, out motPasse ,out courriel);

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
            
            BusinessObject.SupprimerUsager(pUsager.ID ); 
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
        ///A test for Getusager
        ///</summary>
        [TestMethod()]
        public void Getusager()
        {
            BO BusinessObject = new BO(); // 
            string nom;
            string nomUsager;
            string motPasse;
            string courriel;
            Usager_Entite pUsager = _CreerUsager(out nom, out nomUsager, out motPasse, out courriel);

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

            BusinessObject.SupprimerUsager(pUsager.ID);
        }

                /// <summary>
        ///A test for Login
        ///</summary>
        [TestMethod()]
        public void LoginTest()
        {
            string nom;
            string nomUsager;
            string motPasse;
            string courriel;
            
            BO businessObject = new BO(); // TODO: Initialize to an appropriate value
            
            Usager_Entite expected = _CreerUsager(out nom, out nomUsager, out motPasse, out courriel);
            expected=businessObject.CreerUsager(expected);
            Usager_Entite actual = businessObject.Login(nomUsager, motPasse);

            Assert.IsNotNull(actual, "Login a retourné NULL");
            Assert.IsTrue(string.Compare(actual.Nom, expected.Nom) == 0);
            Assert.IsTrue(string.Compare(actual.NomUsager, expected.NomUsager) == 0);
            Assert.IsTrue(string.Compare(actual.MotDePasse, expected.MotDePasse) != 0); // Le mot de passe est hashe
            Assert.IsTrue(string.Compare(actual.Courriel, expected.Courriel) == 0);
            Assert.IsTrue(actual.ID > 0);

            Usager_Entite mauvaisUsager = businessObject.Login(nomUsager, "MauvaisMotDePasse");
            Assert.IsNull(mauvaisUsager, "Login a retourné un usager avec un mauvais mot de passe");

            businessObject.SupprimerUsager(actual.ID);

            actual = businessObject.Login(nomUsager, motPasse);
            Assert.IsNull(actual, "Login a retourné un usager après sa suppression");
        }
    }
}
