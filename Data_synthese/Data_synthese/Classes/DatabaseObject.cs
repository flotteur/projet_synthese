using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entites_Synthese;


namespace Data_synthese.Classes
{
    public class DatabaseObject : IDisposable
    {
        public static int erreur;
        public DatabaseObject()
        {
            this.dbContext = new synthese_dbEntities();
            Crypteur = new Encription();
        }

        #region Propriétés

        private Encription Crypteur { get; set; }
        public synthese_dbEntities dbContext { get; set; }

        /// <summary>
        /// Cette clé permet d'encoder et de décoder les informations qui doivent être vues par els utilisateurs du programme
        /// Le nom des autres usagers et les noms de profiles
        /// </summary>
        private string GlobalKey
        {
            // TODO Cette clé ne devrait pas être hard codée mais provenir d'un serveur externe
            get
            {
                return "FD7189C5-6559-45C4-AB7C-9ECAC97DC5B1";
            }
        }

        #endregion

        #region Méthodes publiques

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        #endregion

        #region Usagers

        public Usager_Entite GetUsager(string pUser)
        {
            Usager_Entite usag = null;
            usager userRow = null;

            //Dans le cache
            var userRows = (from row in dbContext.usager.Local
                            select row);
            if (userRows.Any())
                foreach (usager row in userRows)

                    if (row.NomUsager == pUser)
                    {
                        userRow = row;
                    }

            // Si on pas trouvé dans le cache on va dans la BD
            if (userRow == null)
            {
                userRows = (from row in dbContext.usager
                            select row);
                if (userRows != null)
                    foreach (usager row in userRows)

                        if (row.NomUsager == pUser)
                        {
                            userRow = row;
                            break;
                        }
            }

            //TODO: il manque des propriétés dans l'usager...
            if (userRow != null)
            {
                usag = new Usager_Entite();
                usag.ID = userRow.Id;

                usag.MotDePasse = userRow.MotPasse;
                usag.NomUsager = userRow.NomUsager;
                usag.Courriel = userRow.Courriel;
            }
            return usag;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pUsager"></param>
        /// <returns></returns>
        public Usager_Entite InsertUsager(Usager_Entite pUsager)
        {

            Usager_Entite newUsager = InsertUsager(pUsager.Nom,
                                                    pUsager.NomUsager,
                                                    pUsager.MotDePasse,
                                                    pUsager.EstAdministrateur,
                                                    pUsager.Courriel);
            return newUsager;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pNom"></param>
        /// <param name="pUsername"></param>
        /// <param name="pPassword"></param>
        /// <param name="pEstAdministrateur"></param>
        /// <param name="pCourriel"></param>
        /// <returns></returns>
        public Usager_Entite InsertUsager(string pNom,
        string pUsername,
        string pPassword,
        bool pEstAdministrateur,
        String pCourriel)
        {
            Usager_Entite usag;
            Encription crypteur = new Encription();

            // On s'assure que le username n'existe pas déjà
            var userNameRow = (from row in dbContext.usager.Local 
                           where row.NomUsager == pUsername
                           select row);
            if ((userNameRow != null) && (userNameRow.ToList().Count == 0))
                userNameRow = (from row in dbContext.usager
                               where row.NomUsager == pUsername
                               select row);
            if ((userNameRow != null) && (userNameRow.ToList().Count >0 ))
            {
               // err //définir des erreurs et finaliser le test
                throw new Exceptions.UsagerExistantException();
                
            }
            var courrielRow = (from row in dbContext.usager.Local 
                               where row.Courriel == pCourriel
                               select row);
            if ((userNameRow != null) && (userNameRow.ToList().Count == 0))
                courrielRow = (from row in dbContext.usager
                               where row.Courriel == pCourriel
                               select row);

            if ((userNameRow != null) && (userNameRow.ToList().Count >0 ))
                throw new Exceptions.CourrielExistantException();

            // On s'assure que le courriel n'existe pas déjà

            // On va chercher le dernier ID
           var userRow = (from row in dbContext.usager.Local
                           orderby row.Id descending
                           select row).ToList();
            if (userRow.Count == 0)
                userRow = (from row in dbContext.usager
                           orderby row.Id descending
                           select row).ToList();
            int id;
            if (userRow.Count > 0)
                id = userRow.First().Id;
            else
                id = 0;

            string passwordHash = Encription.GetHash(pPassword);

            usager usagerDB = new usager() { Nom = pNom ,
                                             NomUsager = pUsername,
                                             MotPasse = passwordHash,
                                             Administrateur = pEstAdministrateur,
                                             Courriel = pCourriel,
                                             Id = (id += 1)
            };
            dbContext.usager.Add(usagerDB);
            
            usag = new Usager_Entite(usagerDB.Id,
                pNom,
                pUsername,
                pPassword,
                pEstAdministrateur,
                pCourriel);
            
            return usag;
        }

        /// <summary>
        /// Retourne l'usager ayant l'ID= pID ou un usager vide s'il n'est pas dans la BD
        /// </summary>
        /// <param name="PID"></param>
        /// <returns></returns>
        public Usager_Entite GetUsager(int PID)
        {
            Usager_Entite usag = new Usager_Entite();
            Encription crypteur = new Encription();
            var usagerRow = (from row in dbContext.usager.Local
                             where row.Id == PID
                             select row).FirstOrDefault();
            if (usagerRow == null)
                usagerRow = (from row in dbContext.usager
                             where row.Id == PID
                             select row).FirstOrDefault();

            if (usagerRow != null)
            {
                usag.ID = usagerRow.Id;
                usag.Nom     = usagerRow.Nom;
                usag.NomUsager = usagerRow.NomUsager;
                usag.MotDePasse = usagerRow.MotPasse;
                usag.EstAdministrateur = usagerRow.Administrateur;
                usag.Courriel = usagerRow.Courriel;
            }

            return usag;
        }



        public Boolean DeleteUsager(int pUsagerID)
        {
            var UsagerRow = (from row in dbContext.usager.Local
                             where row.Id == pUsagerID
                             select row).FirstOrDefault();
            if (UsagerRow == null)
                UsagerRow = (from row in dbContext.usager
                             where row.Id == pUsagerID
                             select row).FirstOrDefault();
            if (UsagerRow != null)
            {
                dbContext.usager.Remove(UsagerRow);

                return true;
            }
            return false;
        }


        public Boolean DeleteUsager(string pUserName)
        {
            var UsagerRow = (from row in dbContext.usager.Local
                             where row.NomUsager == pUserName
                             select row).FirstOrDefault();
            if (UsagerRow == null)
                UsagerRow = (from row in dbContext.usager
                             where row.NomUsager == pUserName
                             select row).FirstOrDefault();
            if (UsagerRow != null)
            {
                dbContext.usager.Remove(UsagerRow);

                return true;
            }
            return false;
        }

        
        #endregion


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dbContext != null)
                    dbContext.Dispose();
            }
        }

        ~DatabaseObject()
        {
            Dispose(false);
        }

        /// <summary>
        /// Effece tous les enregistrements de la BD
        /// </summary>
        public void ClearDatabase()
        {
            var usagerRows = from row in dbContext.usager
                             select row;

            foreach (var row in usagerRows)
                DeleteUsager(row.Id);
        }
    } // class
}
