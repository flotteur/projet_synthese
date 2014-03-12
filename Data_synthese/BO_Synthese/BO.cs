using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entites_Synthese;
using Data_synthese;
using Data_synthese.Classes;

namespace BO_Synthese
{
    /// <summary>
    /// Classe représentant la couche affaires
    /// </summary>
    public partial class BO : IDisposable
    {
        private DatabaseObject database = new DatabaseObject();
        private string _MessageErreur = string.Empty;
        public string MessageErreur
        {
            get
            {
                return _MessageErreur;
            }
        }

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
            Usager_Entite retour = new Usager_Entite();
            try{

            retour = database.GetUsager(pID);
            }
            catch (Exception ex)
            {
                retour.MessageErreur = ex.Message;
                this._MessageErreur = ex.Message;
            }
            return retour;
        }

        /// <summary>
        /// Obtient un usager à partir de son UserName
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        public Usager_Entite Getusager(string pUserName)
        {
            Usager_Entite retour = new Usager_Entite();
            try
            {

                retour = database.GetUsager(pUserName);
            }
            catch (Exception ex)
            {
                retour.MessageErreur = ex.Message;
                this._MessageErreur = ex.Message;
            }
            return retour;
        }
        #endregion

        #region " CreerUsager "
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pUsager"></param>
        /// <returns></returns>
        public Usager_Entite CreerUsager(Usager_Entite pUsager)
        {
            this._MessageErreur = string.Empty;
            Usager_Entite usager = new Usager_Entite();

            try
            {
                usager = database.InsertUsager(pUsager);
            }

            catch (Exception ex)
            {
                usager.MessageErreur = ex.Message;
                this._MessageErreur = ex.Message;
            }
            return usager;
        }

        public bool SupprimerUsager(string pUserName)
        {
            this._MessageErreur = string.Empty;
            bool retour = false;
            try
            {
                retour = database.DeleteUsager(pUserName);
            }
            catch (Exception ex)
            {

                this._MessageErreur = ex.Message;
            }
            return retour;
        }

        public bool SupprimerUsager(int pID)
        {

            this._MessageErreur = string.Empty;
            bool retour = false;
            try
            {
                retour = database.DeleteUsager(pID);
            }
            catch (Exception ex)
            {
                this._MessageErreur = ex.Message;
            }
            return retour;
        }

        public Usager_Entite ObtenirUsager(int pID)
        {

            return database.GetUsager(pID);
        }
        #endregion

        #region " DeleteUsager "

        public bool DeleteUsager(int pID)
        {


            return database.DeleteUsager(pID);
        }

        #endregion

        public Usager_Entite UpdateUsager(Usager_Entite pUsager)
        {
            Usager_Entite usager = new Usager_Entite();
            try
            {
                return database.UpdateUsager(pUsager);
            }
            catch (Exception ex)
            {
                pUsager.MessageErreur = ex.Message;
                return pUsager;
            }
        }

        #region " Login "
        /// <summary>
        /// Effecute le login de l'usager
        /// </summary>
        /// <param name="pUser"></param>
        /// <param name="pPassword"></param>
        /// <returns>Retourne l'usager en cas de succès, null sinon</returns>
        public Usager_Entite Login(string pUser, string pPassword)
        {
            Usager_Entite usager = new Usager_Entite();
            try
            {
                usager = database.Login(pUser, pPassword);
                usager.MotDePasse = string.Empty ;
            }
            catch (Exception ex)
            {
                this._MessageErreur = ex.Message;
                usager.MessageErreur = ex.Message ;
                
            }

            return usager;
        }

        #endregion

        #region " LogOut "

        public void LogOut(){
        
            database.Logout();
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
