using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entites_Synthese;
using System.Data.Entity.Validation;

namespace Data_synthese.Classes
{
    public class DatabaseObject : IDisposable
    {
        private readonly Session _session = Session.getInstance();
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
            SaveChanges(this.dbContext);
        }
        /// <summary>
        /// Wrapper for SaveChanges adding the Validation Messages to the generated exception
        /// </summary>
        /// <param name="context">The context.</param>
        private void SaveChanges(synthese_dbEntities context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" + sb, ex); // Add the original exception as the innerException
            }
        }
        #endregion

        public Usager_Entite Login(string pUser, string pPassword)
        {

            string hash = string.Empty;
            Usager_Entite usager = GetUsager(pUser);
            if (usager != null)
            {
                hash = Encription.GetHash(pPassword);

                if (Encription.VerifiyHash(pPassword, usager.MotDePasse))
                {
                    _session.usager = usager;
                    return usager;
                }
            }
            else

                throw new Exception(Constantes.ERREUR_LOGIN);

            return null;
        }

        public void Logout()
        {

            _session.usager = null;
        }

        #region Usagers

        #region " GetUsager "
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pUser"></param>
        /// <returns></returns>
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

            if (userRow != null)
            {
                usag = new Usager_Entite();
                usag.ID = userRow.Id;
                usag.EstAdministrateur = userRow.Administrateur;
                usag.Nom = userRow.Nom;
                usag.MotDePasse = userRow.MotPasse;
                usag.NomUsager = userRow.NomUsager;
                usag.Courriel = userRow.Courriel;
            }
            else
                usag.MessageErreur = Constantes.ERREUR_USAGER_INEXISTANT;

            return usag;
        }
        #endregion

        # region " InsertUsager "
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
        #endregion

        #region " InsertUsager "
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
            Usager_Entite usag = new Usager_Entite(0,
                pNom,
                pUsername,
                pPassword,
                pEstAdministrateur,
                pCourriel);
            if (usag.Validate() == false )
                throw new Exception(Classes.Constantes.ERREUR_INFOS_MANQUANTES);
           
           // On s'assure que le username n'existe pas déjà
            var userNameRow = (from row in dbContext.usager.Local
                                   where row.NomUsager == pUsername
                                   select row);
            if ((userNameRow != null) && (userNameRow.ToList().Count == 0))
                    userNameRow = (from row in dbContext.usager
                                   where row.NomUsager == pUsername
                                   select row);
            if ((userNameRow != null) && (userNameRow.ToList().Count > 0))
            {
                // err //définir des erreurs et finaliser le test
                throw new Exception(Classes.Constantes.ERREUR_NOM_UTILISATEUR_EXISTANT);

            }
            var courrielRow = (from row in dbContext.usager.Local
                                   where row.Courriel == pCourriel
                                   select row);
            if ((courrielRow != null) && (courrielRow.ToList().Count == 0))
                    courrielRow = (from row in dbContext.usager
                                   where row.Courriel == pCourriel
                                   select row);

            if ((courrielRow != null) && (courrielRow.ToList().Count > 0))
                    throw new Exception(Constantes.ERREUR_COURRIEL_EXISTANT);

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

                usager usagerDB = new usager()
                {
                    Nom = pNom,
                    NomUsager = pUsername,
                    MotPasse = passwordHash,
                    Administrateur = pEstAdministrateur,
                    Courriel = pCourriel,
                    Id = (id += 1)
                };
                dbContext.usager.Add(usagerDB);

            usag.ID = usagerDB.Id;
            
           return usag;
        }

        #endregion

        #region " GetUsager "
        /// <summary>
        /// Retourne l'usager ayant l'ID= pID ou un usager vide s'il n'est pas dans la BD
        /// </summary>
        /// <param name="PID"></param>
        /// <returns></returns>
        public Usager_Entite GetUsager(int PID)
        {
            Usager_Entite usag = new Usager_Entite();
            var usagerRow = (from row in dbContext.usager.Local
                             where row.Id == PID
                             select row).FirstOrDefault();
            if (usagerRow == null)
                usagerRow = (from row in dbContext.usager
                             where row.Id == PID
                             select row).FirstOrDefault();

            if (usagerRow != null)
            {
                usag = usagerRow.Convertir();
            }
            else
                usag.MessageErreur = Constantes.ERREUR_USAGER_INEXISTANT;

            return usag;
        }
        #endregion

        #region " DeleteUsager "
        public Boolean DeleteUsager(int pUsagerID)
        {
            if ((_session.usager != null) && (_session.usager.EstAdministrateur == true))
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
            }
            else
                throw new Exception(Constantes.ERREUR_ADMIN_REQUIS);
            return false;
        }


        public Boolean DeleteUsager(string pUserName)
        {
            if ((_session.usager != null) && (_session.usager.EstAdministrateur == true))
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
            }
            else
                throw new Exception(Constantes.ERREUR_ADMIN_REQUIS);
            return false;
        }
        #endregion

        #region "UpdateUsager"

        public Usager_Entite UpdateUsager(Usager_Entite pUsager)
        {
            var usagerRow = (from row in dbContext.usager.Local
                             where row.Id == pUsager.ID
                             select row).FirstOrDefault();
            if (usagerRow == null)
                usagerRow = (from row in dbContext.usager
                             where row.Id == pUsager.ID
                             select row).FirstOrDefault();

            if (usagerRow != null)
            {
                usagerRow.Nom = pUsager.Nom;
                usagerRow.NomUsager = pUsager.NomUsager;
                usagerRow.MotPasse = pUsager.MotDePasse;
                usagerRow.Administrateur = pUsager.EstAdministrateur;
                usagerRow.Courriel = pUsager.Courriel;
            }
            else
                pUsager.MessageErreur = Constantes.ERREUR_USAGER_INEXISTANT;

            return pUsager;

        }
        #endregion

        #endregion
        #region " Alerte "

        public Alerte_Entite insertAlert( Alerte_Entite pAlerte){
        
           

             if (pAlerte.Validate() == false)
                throw new Exception(Classes.Constantes.ERREUR_INFOS_MANQUANTES);

             // On s'assure que la row n'existe pas déjà
             var alerteRows = (from row in dbContext.alerte.Local
                               where row.IDUsager == pAlerte.IDUsager && row.IDOiseau == pAlerte.IDOiseau
                               select row);
             if ((alerteRows == null) || (alerteRows.ToList().Count == 0))
                 alerteRows = (from row in dbContext.alerte
                               where row.IDUsager == pAlerte.IDUsager && row.IDOiseau == pAlerte.IDOiseau
                               select row);

             if ((alerteRows == null) || (alerteRows.ToList().Count == 0))
             {
                // Si l'alerte n'existe pas déjà, on la crée
                 // On va chercher le dernier ID
                var alerteRow = (from row in dbContext.alerte
                                 orderby row.Id descending
                                 select row).FirstOrDefault();
                int ID = 0;
                 if (alerteRow != null)
                    ID = alerteRow.Id;
                ID += 1;
                alerte alerte = new alerte();
                alerte.Convertir(pAlerte);
                dbContext.alerte.Add(alerte);
             }

            return pAlerte;
        }

        /// <summary>
        /// Supprime des alertes
        /// 
        /// Si ID est renseigné supprime cette alerte
        /// si ISUsager est renseigné supprime toutes les alertes de ceet usager
        /// Si IDOiseau es renseigné Supprime toutes les alertes de cet oiseau
        /// Si aucun de ces champs n'est renseigné Supprime toutes les alertes
        /// </summary>
        /// <param name="pAlerte"></param>
        public bool DeleteAlerte(Alerte_Entite pAlerte) {
            
            Boolean retour = false;
            IEnumerable<alerte> alertes = null;
            try{
                // Une alerte en praticulier
                if (pAlerte.ID > 0)
                {
                    alertes = (from row in dbContext.alerte
                               where row.Id == pAlerte.ID
                               select row);
                // Les alertes d'un usager
                if (pAlerte.IDUsager > 0)
                {
                    alertes = (from row in dbContext.alerte
                               where row.IDUsager == pAlerte.IDUsager
                               select row);

                    // Les alertes reliées à un oiseau
                }
                else if (pAlerte.IDOiseau > 0)
                {
                    alertes = (from row in dbContext.alerte
                               where row.IDOiseau == pAlerte.IDOiseau
                               select row);
                }
                else
                    // Toutes les alertes
                    alertes = from row in dbContext.alerte
                              orderby row.Id
                              select row;
                }
                if (alertes !=null){
                    foreach (alerte item in alertes)
		 
                    dbContext.alerte.Remove(item);
                        retour = true;
                
                }
             }
            catch{
            
            }

            return retour;
        }

        public Alerte_Entite  GetAlerte(Alerte_Entite pAlerte)
        {
            Alerte_Entite retour = new Alerte_Entite();
            var alerte = (from row in dbContext.alerte
                          where row.Id == pAlerte.ID
                          select row).FirstOrDefault();
            if (alerte != null){
            
                retour = alerte.Convertir();            
            }
            
                return retour;
 
            }

        public List<Alerte_Entite> GetAlertes( Alerte_Entite pAlerte ){
        
            List<Alerte_Entite> retour = new List<Alerte_Entite>();
            IEnumerable<alerte> alertes = null;

            // Les alertes d'un usager
            if (pAlerte.IDUsager > 0 ){
                alertes = (from row in dbContext.alerte
                           .Include("oiseaux")
                           .Include("usager")
                           where row.IDUsager == pAlerte.IDUsager
                           select row);

                // Les alertes reliées à un oiseau
            }else if (pAlerte.IDOiseau >0){
                alertes = (from row in dbContext.alerte
                           .Include("usager")
                           .Include("oiseaux")
                           where row.IDOiseau == pAlerte.IDOiseau
                           select row);
            }
            else
                // Toutes les alertes
                    alertes = from row in dbContext.alerte
                              .Include("oiseaux")
                              .Include("usager")
                              orderby row.Id
                              select row;

            if ((alertes != null)&&(alertes.Count() >0))
            {
                foreach (alerte item in alertes)
                {
                    Alerte_Entite alerteEnt = new Alerte_Entite();
                    alerteEnt = item.Convertir();
                    retour.Add(alerteEnt);
                }
            }
            return retour;
        }
        #endregion

        #region " Oiseaux "
        #region " GetOiseau "

        public OiseauxList_Entite GetOiseaux(int pQte, int pStart) {

            
            OiseauxList_Entite retour = new OiseauxList_Entite() { QteTotale = (from row in dbContext.oiseau
                                                                                select row).Count() };
                
            IQueryable<oiseau> liste = null;

            if (retour.QteTotale > 0) {
                if (pQte == 0)
                {
                    liste = from row in dbContext.oiseau
                                .Include("crioiseaux")
                                .Include("photos")
                            where row.Id > pQte
                            select row;
                }
                else{
                    liste = (from row in dbContext.oiseau
                                .Include("crioiseaux")
                                .Include("photos")
                             where row.Id > pStart
                            orderby row.Id 
                            select row).Take(pQte);
                }
            
            }
            
            if (liste !=null)
                foreach( oiseau oiseau in liste)
                    retour.Oiseaux.Add(oiseau.Convertir());

            return retour;
        }

        /// <summary>
        /// Retourne l'Oiseau ayant l'ID= pID ou un Oiseau vide s'il n'est pas dans la BD
        /// </summary>
        /// <param name="PID"></param>
        /// <returns></returns>
        public Oiseau_Entite GetOiseau(int PID)
        {
            Oiseau_Entite oiseau = new Oiseau_Entite();
            var OiseauRow = (from row in dbContext.oiseau.Local
                             where row.Id == PID
                             select row).FirstOrDefault();
            if (OiseauRow == null)
                OiseauRow = (from row in dbContext.oiseau
                             .Include("alertes")
                             .Include("crioiseaux")
                             .Include("observations")
                             .Include("photos")
                             where row.Id == PID
                             select row).FirstOrDefault();

            if (OiseauRow != null)
                oiseau = OiseauRow.Convertir();
            else
                oiseau.MessageErreur = Constantes.ERREUR_OISEAU_INEXISTANT;
            return oiseau;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEspece"></param>
        /// <returns></returns>
        public Oiseau_Entite GetOiseau(string pEspece)
        {
            Oiseau_Entite oiseauEnt = new Oiseau_Entite();
            oiseau oiseauRow = null;

            //Dans le cache
            var oiseauRows = (from row in dbContext.oiseau.Local
                            select row);
            if (oiseauRows.Any())
                foreach (oiseau row in oiseauRows)

                    if (row.Espece.Equals(pEspece,StringComparison.OrdinalIgnoreCase))
                    {
                        oiseauRow = row;
                    }

            // Si on pas trouvé dans le cache on va dans la BD
            if (oiseauRow == null)
            {
                oiseauRows = (from row in dbContext.oiseau
                            select row);
                if (oiseauRows != null)
                    foreach (oiseau row in oiseauRows)

                        if (row.Espece.Equals(pEspece, StringComparison.OrdinalIgnoreCase))
                        {
                            oiseauRow = row;
                            break;
                        }
            }
            if (oiseauRow == null)
                oiseauEnt.MessageErreur = Constantes.ERREUR_OISEAU_INEXISTANT;
            else
                oiseauEnt = oiseauRow.Convertir();
                
            return oiseauEnt;
        }
        #endregion
        
        #region " InsertOiseau "
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pOiseau"></param>
        /// <returns></returns>
        public Oiseau_Entite InsertOiseau(oiseau pOiseau)
        {
            Oiseau_Entite oiseau = new Oiseau_Entite() { CrisOiseau = pOiseau.Convertir(pOiseau.crioiseaux),
                            Description = pOiseau.Description, 
                            Photos = pOiseau.Convertir(pOiseau.photos), 
                            Espece =pOiseau.Espece , 
                            ID = pOiseau.Id };
             
            if (oiseau.Validate() == false)
                throw new Exception(Classes.Constantes.ERREUR_INFOS_MANQUANTES);

            // On s'assure que le username n'existe pas déjà
            var oiseauRows = (from row in dbContext.oiseau.Local
                               where row.Espece == pOiseau.Espece || row.Id == pOiseau.Id 
                               select row);
            if ((oiseauRows != null) && (oiseauRows.ToList().Count == 0))
                oiseauRows = (from row in dbContext.oiseau
                               where row.Espece == pOiseau.Espece || row.Id == pOiseau.Id 
                               select row);
            if ((oiseauRows != null) && (oiseauRows.ToList().Count > 0))
            {
                // err //définir des erreurs et finaliser le test
                throw new Exception(Classes.Constantes.ERREUR_OISEAU_INEXISTANT);

            }

            // On va chercher le dernier ID
            pOiseau.Id  = (from row in dbContext.oiseau
                           select row).Count() + 1;
                        
            dbContext.oiseau.Add(pOiseau);

            return pOiseau.Convertir(); 
        }

        #endregion

        #region " DeleteOiseau "
        public Boolean DeleteOiseau(int pOiseauID)
        {
            if ((_session.usager  != null) && (_session.usager.EstAdministrateur == true))
            {
                var OiseauRow = (from row in dbContext.oiseau.Local
                                 where row.Id == pOiseauID
                                 select row).FirstOrDefault();
                if (OiseauRow == null)
                    OiseauRow = (from row in dbContext.oiseau
                                 where row.Id == pOiseauID
                                 select row).FirstOrDefault();
                if (OiseauRow != null)
                {
                    dbContext.oiseau.Remove(OiseauRow);

                    return true;
                }
            }
            else
                throw new Exception(Constantes.ERREUR_ADMIN_REQUIS);
            return false;
        }


        public Boolean DeleteOiseau(string pEspece)
        {
            if ((_session.usager != null) && (_session.usager.EstAdministrateur == true))
            {
                var OiseauRow = (from row in dbContext.oiseau.Local
                                 where row.Espece == pEspece
                                 select row).FirstOrDefault();
                if (OiseauRow == null)
                    OiseauRow = (from row in dbContext.oiseau
                                 where row.Espece == pEspece
                                 select row).FirstOrDefault();
                if (OiseauRow != null)
                {
                    dbContext.oiseau.Remove(OiseauRow);

                    return true;
                }
            }
            else
                throw new Exception(Constantes.ERREUR_ADMIN_REQUIS);
            return false;
        }

        #endregion
        
        #region "UpdateOiseau"

        public Oiseau_Entite UpdateOiseau(Oiseau_Entite pOiseau)
        {

            var OiseauRow = (from row in dbContext.oiseau.Local
                             where row.Id == pOiseau.ID || string.CompareOrdinal( row.Espece, pOiseau.Espece) == 0
                             select row).FirstOrDefault();
            if (OiseauRow == null)
                OiseauRow = (from row in dbContext.oiseau
                             where row.Id == pOiseau.ID || string.CompareOrdinal( row.Espece, pOiseau.Espece) == 0
                             select row).FirstOrDefault();

            if (OiseauRow != null)
            {
                OiseauRow.Description = pOiseau.Description;
                OiseauRow.Espece = pOiseau.Espece;
                
            }
            else
                pOiseau.MessageErreur = Constantes.ERREUR_OISEAU_INEXISTANT;

            return pOiseau;

        }
        

#endregion
        #endregion

        #region " CriOiseaux "
     
        #region " GetCriOiseau "

        /// <summary>
        /// Retourne l'CriOiseau ayant l'ID= pID ou un CriOiseau vide s'il n'est pas dans la BD
        /// </summary>
        /// <param name="PID"></param>
        /// <returns></returns>
        public CriOiseau_Entite GetCriOiseau(int PID)
        {
            CriOiseau_Entite CriOiseau = new CriOiseau_Entite();
            
            var CriOiseauRow = (from row in dbContext.crioiseau.Local
                             where row.Id == PID
                             select row).FirstOrDefault();
            if (CriOiseauRow == null)
                CriOiseauRow = (from row in dbContext.crioiseau
                             where row.Id == PID
                             select row).FirstOrDefault();

            if (CriOiseauRow != null)
                CriOiseau = CriOiseauRow.Convertir();
            else
                CriOiseau.MessageErreur = Constantes.ERREUR_CRIOISEAU_INEXISTANT;
            return CriOiseau;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDescription"></param>
        /// <returns></returns>
        public CriOiseau_Entite GetCriOiseau(string pDescription)
        {
            CriOiseau_Entite CriOiseauEnt = new CriOiseau_Entite();
            crioiseau CriOiseauRow = null;

            //Dans le cache
            var CriOiseauRows = (from row in dbContext.crioiseau.Local
                              select row);
            if (CriOiseauRows.Any())
                foreach (crioiseau row in CriOiseauRows)

                    if (row.Description.Equals(pDescription, StringComparison.OrdinalIgnoreCase))
                    {
                        CriOiseauRow = row;
                    }

            // Si on pas trouvé dans le cache on va dans la BD
            if (CriOiseauRow == null)
            {
                CriOiseauRows = (from row in dbContext.crioiseau
                              select row);
                if (CriOiseauRows != null)
                    foreach (crioiseau row in CriOiseauRows)

                        if (row.Description.Equals(pDescription, StringComparison.OrdinalIgnoreCase))
                        {
                            CriOiseauRow = row;
                            break;
                        }
            }
            if (CriOiseauRow == null)
                CriOiseauEnt.MessageErreur = Constantes.ERREUR_CRIOISEAU_INEXISTANT;
            else
                CriOiseauEnt = CriOiseauRow.Convertir();

            return CriOiseauEnt;
        }
        #endregion

        #region " InsertCriOiseau "
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCriOiseau"></param>
        /// <returns></returns>
        public CriOiseau_Entite InsertCriOiseau(crioiseau pCriOiseau)
        {
            CriOiseau_Entite CriOiseau = new CriOiseau_Entite()
            {
                 Son = pCriOiseau.Son ,
                Description = pCriOiseau.Description,
                ID = pCriOiseau.Id
            };

            if (CriOiseau.Validate() == false)
                throw new Exception(Classes.Constantes.ERREUR_INFOS_MANQUANTES);

            // On va chercher le dernier ID
            pCriOiseau.Id = (from row in dbContext.crioiseau
                             select row).Count() + 1;


            dbContext.crioiseau.Add(pCriOiseau);

            return pCriOiseau.Convertir();
        }

        #endregion

        #region " DeleteCriOiseau "
        public Boolean DeleteCriOiseau(int pID)
        {
            if ((_session.usager != null) && (_session.usager.EstAdministrateur == true))
            {
                var CriOiseauRow = (from row in dbContext.crioiseau.Local
                                 where row.Id == pID
                                 select row).FirstOrDefault();
                if (CriOiseauRow == null)
                    CriOiseauRow = (from row in dbContext.crioiseau
                                 where row.Id == pID
                                 select row).FirstOrDefault();
                if (CriOiseauRow != null)
                {
                    dbContext.crioiseau.Remove(CriOiseauRow);

                    return true;
                }
            }
            else
                throw new Exception(Constantes.ERREUR_ADMIN_REQUIS);
            return false;
        }

        #endregion

        #region "UpdateCriOiseau"

        public CriOiseau_Entite UpdateCriOiseau(CriOiseau_Entite pCriOiseau)
        {

            var CriOiseauRow = (from row in dbContext.crioiseau.Local
                             where row.Id == pCriOiseau.ID 
                             select row).FirstOrDefault();
            if (CriOiseauRow == null)
                CriOiseauRow = (from row in dbContext.crioiseau
                             where row.Id == pCriOiseau.ID 
                             select row).FirstOrDefault();

            if (CriOiseauRow != null)
            {
                CriOiseauRow.Description = pCriOiseau.Description;
                CriOiseauRow.Son= pCriOiseau.Son;
                CriOiseauRow.IDOiseau = pCriOiseau.IDOiseau;
                
            }
            else
                pCriOiseau.MessageErreur = Constantes.ERREUR_CRIOISEAU_INEXISTANT;

            return pCriOiseau;

        }


        #endregion
        #endregion
        
        #region " Photo "

        #region " GetPhoto "

        /// <summary>
        /// Retourne l'Photo ayant l'ID= pID ou un Photo vide s'il n'est pas dans la BD
        /// </summary>
        /// <param name="PID"></param>
        /// <returns></returns>
        public Photo_Entite GetPhoto(int PID)
        {
            Photo_Entite Photo = new Photo_Entite();

            var PhotoRow = (from row in dbContext.photo.Local
                                where row.Id == PID
                                select row).FirstOrDefault();
            if (PhotoRow == null)
                PhotoRow = (from row in dbContext.photo
                                where row.Id == PID
                                select row).FirstOrDefault();

            if (PhotoRow != null)
                Photo = PhotoRow.Convertir();
            else
                Photo.MessageErreur = Constantes.ERREUR_PHOTOOISEAU_INEXISTANTE;

            return Photo;
        }


        
        #endregion

        #region " InsertPhoto "
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pPhoto"></param>
        /// <returns></returns>
        public Photo_Entite InsertPhoto(photo pPhoto)
        {
            Photo_Entite Photo = new Photo_Entite()
            {
                Image = pPhoto.Image,
                Description = pPhoto.Description,
                ID = pPhoto.Id,
                IDOiseau = pPhoto.IDOiseau
                   
            };

            if (Photo.Validate() == false)
                throw new Exception(Classes.Constantes.ERREUR_INFOS_MANQUANTES);

            // On va chercher le dernier ID
            pPhoto.Id = (from row in dbContext.photo
                             select row).Count() + 1;


            dbContext.photo.Add(pPhoto);

            return pPhoto.Convertir();
        }

        #endregion

        #region " DeletePhoto "
        public Boolean DeletePhoto(int pID)
        {
            if ((_session.usager != null) && (_session.usager.EstAdministrateur == true))
            {
                var PhotoRow = (from row in dbContext.photo.Local
                                    where row.Id == pID
                                    select row).FirstOrDefault();
                if (PhotoRow == null)
                    PhotoRow = (from row in dbContext.photo
                                    where row.Id == pID
                                    select row).FirstOrDefault();
                if (PhotoRow != null)
                {
                    dbContext.photo.Remove(PhotoRow);

                    return true;
                }
            }
            else
                throw new Exception(Constantes.ERREUR_ADMIN_REQUIS);
            return false;
        }

        #endregion

        #region "UpdatePhoto"

        public Photo_Entite UpdatePhoto(Photo_Entite pPhoto)
        {

            var PhotoRow = (from row in dbContext.photo.Local
                                where row.Id == pPhoto.ID
                                select row).FirstOrDefault();
            if (PhotoRow == null)
                PhotoRow = (from row in dbContext.photo
                                where row.Id == pPhoto.ID
                                select row).FirstOrDefault();

            if (PhotoRow != null)
            {
                PhotoRow.Description = pPhoto.Description;
                PhotoRow.Image = pPhoto.Image;
                PhotoRow.IDOiseau = pPhoto.IDOiseau;
                
            }
            else
                pPhoto.MessageErreur = Constantes.ERREUR_PHOTOOISEAU_INEXISTANTE;

            return pPhoto;

        }


        #endregion
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
