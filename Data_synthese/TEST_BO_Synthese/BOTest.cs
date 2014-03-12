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
        private Usager_Entite _usagerPourTest;
        private static BO _BusinessObject;
        private Usager_Entite _admin;

        private static Usager_Entite _CreerEntiteUsager(out string nom,
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
                EstAdministrateur = false
            };
            return usager;
        }

        private static Usager_Entite _CreerEntiteUsagerAdministrateur()
        {
            Usager_Entite usager = new Usager_Entite
            {
                Nom = "Administrateur",
                NomUsager = "admin",
                MotDePasse = "MotDePasse",
                Courriel = "admin@diq.ca",
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
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            _BusinessObject = new BO(); // 
        }
        //
        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
        }
        //
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            
            string nom;
            string nomUsager;
            string motPasse;
            string courriel;


            Usager_Entite pUsager = _CreerEntiteUsager(out nom, out nomUsager, out motPasse, out courriel);
            Usager_Entite admin = _BusinessObject.ObtenirUsager(1);

            // On doit d'abord être loggue comme administrateur
            admin = _BusinessObject.Login(admin.NomUsager, "MotDePasse");
            // On commence par supprimer l'usager s'il existe
            _BusinessObject.SupprimerUsager(pUsager.NomUsager);
            _BusinessObject.SaveChanges();

            _usagerPourTest = _BusinessObject.CreerUsager(pUsager);
            _usagerPourTest = _BusinessObject.ObtenirUsager(_usagerPourTest.ID);

            Assert.IsNotNull(_usagerPourTest, "CreerUsager a retourné NULL");
            Assert.IsTrue(string.Compare(_usagerPourTest.Nom, nom) == 0);
            Assert.IsTrue(string.Compare(_usagerPourTest.NomUsager, nomUsager) == 0);
            Assert.IsTrue(string.Compare(_usagerPourTest.MotDePasse, motPasse) != 0); // Le mot de passe est hashe
            Assert.IsTrue(string.Compare(_usagerPourTest.Courriel, courriel) == 0);
            Assert.IsTrue(_usagerPourTest.ID > 0);

            _admin = _BusinessObject.Getusager("admin");
        }
        //
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {

            _BusinessObject.SupprimerUsager(_usagerPourTest.ID);
        }
        //
        #endregion

        
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
        /// On doit suivre en debug pour la faire passer car il est impossible de créer un usager si on est pas admin
        /// </summary>
        [TestMethod()]
        public void CreerAdmin()
        {
                    
            _admin = _CreerEntiteUsagerAdministrateur();
            _admin = _BusinessObject.CreerUsager(_admin);
            _BusinessObject.SaveChanges();
            Assert.IsNotNull(_admin, "CreerUsager a retourné NULL");
        }
        /// <summary>
        ///A test for CreerUsager OK 2014-02-16
        /// S'assurer que l'usager ne peut être créé deux fois
        ///</summary>
        [TestMethod()]
        public void CreerUsagerTest()
        {
                        
            // Pas deux fois le même nomUsager
            _usagerPourTest.Courriel = "raubindiq.ca";
            _usagerPourTest = _BusinessObject.CreerUsager(_usagerPourTest);

            Assert.IsTrue(!string.IsNullOrEmpty(_usagerPourTest.MessageErreur), "CreerUsager on peut insérer deux fois le même username");


            // Pas deux fois le même courriel
            _usagerPourTest.Courriel = "rferland@diq.ca";
            _usagerPourTest.NomUsager = "rferland";
            _usagerPourTest = _BusinessObject.CreerUsager(_usagerPourTest);

            Assert.IsTrue(!string.IsNullOrEmpty(_usagerPourTest.MessageErreur), "CreerUsager on peut insérer deux fois le même courriel");

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
        ///A test for GetusagerTest
        ///</summary>
        [TestMethod()]
        public void GetusagerTest()
        {
           Usager_Entite usagerAVerifier = _BusinessObject.ObtenirUsager(_usagerPourTest.ID);

           Assert.IsNotNull(_usagerPourTest, "CreerUsager a retourné NULL");
           Assert.IsTrue(string.Compare(_usagerPourTest.Nom, usagerAVerifier.Nom) == 0);
           Assert.IsTrue(string.Compare(_usagerPourTest.NomUsager, usagerAVerifier.NomUsager) == 0);
           Assert.IsTrue(string.Compare(_usagerPourTest.MotDePasse, usagerAVerifier.MotDePasse) == 0); // Le mot de passe est hashe
           Assert.IsTrue(string.Compare(_usagerPourTest.Courriel, usagerAVerifier.Courriel ) == 0);
           Assert.IsTrue(_usagerPourTest.ID == usagerAVerifier.ID );
                        
        }

        /// <summary>
        ///A test for Getusager
        ///</summary>
        [TestMethod()]
        public void UpdateUsagerTest()
        {
            Usager_Entite actual = new Usager_Entite();

            Usager_Entite usagerModifie = new Usager_Entite()
            {
                ID = _usagerPourTest.ID,
                Courriel = "NouveauCourriel@diq.ca",
                EstAdministrateur = true,
                MotDePasse = "NouveauMotDepasse",
                Nom = "Nouveau nom",
                NomUsager = "Nouveau nom usager"
            };

            // le retour de la fonction
            actual = _BusinessObject.UpdateUsager(usagerModifie);

            Assert.IsNotNull(actual, "UpdateUsager a retourné NULL");
            Assert.IsTrue( string.IsNullOrEmpty(actual.MessageErreur), actual.MessageErreur);
            Assert.IsTrue(string.Compare(actual.Nom, usagerModifie.Nom) == 0);
            Assert.IsTrue(string.Compare(actual.NomUsager, usagerModifie.NomUsager) == 0);
            Assert.IsTrue(string.Compare(actual.MotDePasse, usagerModifie.MotDePasse) == 0, "Le mot de passe n'a pas été modifié"); // Le mot de passe original
            Assert.IsTrue(string.Compare(actual.Courriel, usagerModifie.Courriel) == 0);
            Assert.IsTrue(actual.ID == _usagerPourTest.ID );

            actual = _BusinessObject.ObtenirUsager(actual.ID);

            // Le retour de la BD
            Assert.IsNotNull(actual, "UpdateUsager a retourné NULL");
            Assert.IsTrue(string.IsNullOrEmpty(actual.MessageErreur), actual.MessageErreur);
            Assert.IsTrue(string.Compare(actual.Nom, usagerModifie.Nom) == 0);
            Assert.IsTrue(string.Compare(actual.NomUsager, usagerModifie.NomUsager) == 0);
            Assert.IsTrue(string.Compare(actual.MotDePasse, usagerModifie.MotDePasse) != 0); // Le mot de passe est hashe. Il est donc différent de l'original qui ne l'est pas
            Assert.IsTrue(string.Compare(actual.Courriel, usagerModifie.Courriel) == 0);
            Assert.IsTrue(actual.ID > 0);

        }
        /// <summary>
        ///A test for Login
        ///</summary>
        [TestMethod()]
        public void LoginTest()
        {
            Usager_Entite actual = _BusinessObject.Login(_usagerPourTest.NomUsager , "MotDePasse");

            Assert.IsNotNull(actual, "Login a retourné NULL");
            Assert.IsTrue(string.IsNullOrEmpty(_BusinessObject.MessageErreur), _BusinessObject.MessageErreur);
            Assert.IsTrue(string.Compare(actual.Nom, _usagerPourTest.Nom) == 0);
            Assert.IsTrue(string.Compare(actual.NomUsager, _usagerPourTest.NomUsager) == 0);
            Assert.IsTrue(string.Compare(actual.MotDePasse, _usagerPourTest.MotDePasse) == 0); // Le mot de passe est hashe
            Assert.IsTrue(string.Compare(actual.Courriel, _usagerPourTest.Courriel) == 0);
            Assert.IsTrue(actual.ID == _usagerPourTest.ID );

            Usager_Entite mauvaisUsager = _BusinessObject.Login(_usagerPourTest.NomUsager, "MauvaisMotDePasse");
            Assert.IsNull(mauvaisUsager, "Login a retourné un usager avec un mauvais mot de passe");

            // On doit être administrateur pour supprimer un usager
            _BusinessObject.Login(_admin.NomUsager,
                "MotDePasse");
            _BusinessObject.SupprimerUsager(actual.ID);
            Assert.IsTrue(string.IsNullOrEmpty(_BusinessObject.MessageErreur),_BusinessObject.MessageErreur);
            _BusinessObject.SaveChanges();

            actual = _BusinessObject.Login(_usagerPourTest.NomUsager, "MotDePasse");
            Assert.IsNull(actual, "Login a retourné un usager après sa suppression");
        }
    }
}
