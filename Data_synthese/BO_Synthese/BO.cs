using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entites_Synthese ;
using Data_synthese;
using Data_synthese.Classes;

namespace BO_Synthese
{
    /// <summary>
    /// Classe représentant la couche affaires
    /// </summary>
    public class BO :IDisposable
    {
//        #region Session
//        /// <summary>
//        /// Classe privée qui contient les informations sur la session courante
//        /// </summary>
//        /// 
//        private class  Session{
//            public static string PasswordHash { get;  set; }
//            public static string UserName { get;  set; }
//            public static int UserID{get;set;}

            
//        }
//#endregion 
        private DatabaseObject database = new DatabaseObject();


        #region " Méthodes privées "

        //private void InitialiseSession(Usager_Entite pUsager)
        //{

        //    Session.PasswordHash = Encription.GetHash(pUsager.MotDePasse);
        //    Session.UserName = pUsager.NomUsager;
        //    Session.UserID = pUsager.ID;
        //}

        #endregion


        #region " Méthodes publiques "

        #region " Usager "

        #region " Getusager "
        /// <summary>
        /// Obtient un usager à partir de son ID
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        public Usager_Entite Getusager(int pID) {
        
            return database.GetUsager(pID);
        }
        #endregion

        #region " CreerUsager "
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pUsager"></param>
        /// <returns></returns>
        public Usager_Entite CreerUsager(Usager_Entite pUsager) { 
        
            Usager_Entite usager = database.InsertUsager(pUsager);
           
            return usager;
        }
        
        #endregion
        
        #region " Login "
        /// <summary>
        /// Effecute le login de l'usager
        /// </summary>
        /// <param name="pUser"></param>
        /// <param name="pPassword"></param>
        /// <returns>Retourne l'usager en cas de succèes, null sinon</returns>
        public Usager_Entite Login(string pUser, string pPassword)
        {
            Usager_Entite usager = database.GetUsager(pUser);
            if (usager != null)
                if (Encription.VerifiyHash(pPassword,
                    usager.MotDePasse))
                            
                    return usager;
                                              
            return null;
        }
        #endregion


        #endregion
        #endregion

        #region " Database "

        /// <summary>
        /// 
        /// </summary>
        public void SaveChanges()
        {
            this.database.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Supprime toutes les données de la base de données
        /// </summary>
        public void ClearDatabase()
        {
            database.ClearDatabase();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDisposing"></param>
        protected virtual void Dispose(bool pDisposing)
        {
            if (pDisposing)
                if (database != null)
                {
                    database.Dispose();
                    database = null;
                }
        }
        #endregion
                
    }
}
