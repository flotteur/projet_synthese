using System;
using System.Collections.Generic;
using System.Linq;
using Entites_Synthese;
using Data_synthese;
using Data_synthese.Classes;

namespace BO_Synthese
{
    /// <summary>
    /// Classe représentant la couche affaires
    /// </summary>
    public class BO : IDisposable
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

        #region " CriOiseau "

        #region " GetCriOiseau "
        /// <summary>
        /// Obtient un CriOiseau à partir de son ID
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        public CriOiseau_Entite GetCriOiseau(int pID)
        {
            CriOiseau_Entite retour = new CriOiseau_Entite();
            try
            {

                retour = database.GetCriOiseau(pID);
            }
            catch (Exception ex)
            {
                retour.MessageErreur = ex.Message;
                this._MessageErreur = ex.Message;
            }
            return retour;
        }

        /// <summary>
        /// Obtient un CriOiseau à partir de son UserName
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        public CriOiseau_Entite GetCriOiseau(string pUserName)
        {
            CriOiseau_Entite retour = new CriOiseau_Entite();
            try
            {

                retour = database.GetCriOiseau(pUserName);
            }
            catch (Exception ex)
            {
                retour.MessageErreur = ex.Message;
                this._MessageErreur = ex.Message;
            }
            return retour;
        }
        #endregion

        #region " CreerCriOiseau "
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCriOiseau"></param>
        /// <returns></returns>
        public CriOiseau_Entite CreerCriOiseau(CriOiseau_Entite pCriOiseau)
        {
            CriOiseau_Entite retour = new CriOiseau_Entite();
            this._MessageErreur = string.Empty;
            crioiseau CriOiseau = new crioiseau();
            CriOiseau.Convertir(pCriOiseau);

            try
            {
                retour = database.InsertCriOiseau(CriOiseau);
            }

            catch (Exception ex)
            {
                retour.MessageErreur = ex.Message;
                this._MessageErreur = ex.Message;
            }
            return retour;
        }

       public bool SupprimerCriOiseau(int pID)
        {

            this._MessageErreur = string.Empty;
            bool retour = false;
            try
            {
                retour = database.DeleteCriOiseau(pID);
            }
            catch (Exception ex)
            {
                this._MessageErreur = ex.Message;
            }
            return retour;
        }

        public CriOiseau_Entite ObtenirCriOiseau(int pID)
        {

            return database.GetCriOiseau(pID);
        }
        #endregion

        #region " DeleteCriOiseau "

        public bool DeleteCriOiseau(int pID)
        {


            return database.DeleteCriOiseau(pID);
        }

        #endregion

        public CriOiseau_Entite UpdateCriOiseau(CriOiseau_Entite pCriOiseau)
        {
            try
            {
                return database.UpdateCriOiseau(pCriOiseau);
            }
            catch (Exception ex)
            {
                pCriOiseau.MessageErreur = ex.Message;
                return pCriOiseau;
            }
        }
#endregion

        #region " Oiseau "

        #region " GetOiseau "
        /// <summary>
        /// Obtient un Oiseau à partir de son ID
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        public Oiseau_Entite GetOiseau(int pID)
        {
            Oiseau_Entite retour = new Oiseau_Entite();
            try
            {

                retour = database.GetOiseau(pID);
            }
            catch (Exception ex)
            {
                retour.MessageErreur = ex.Message;
                this._MessageErreur = ex.Message;
            }
            return retour;
        }

        /// <summary>
        /// Obtient un Oiseau à partir de son UserName
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        public Oiseau_Entite GetOiseau(string pUserName)
        {
            Oiseau_Entite retour = new Oiseau_Entite();
            try
            {

                retour = database.GetOiseau(pUserName);
            }
            catch (Exception ex)
            {
                retour.MessageErreur = ex.Message;
                this._MessageErreur = ex.Message;
            }
            return retour;
        }
        #endregion

        #region " CreerOiseau "
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pOiseau"></param>
        /// <returns></returns>
        public Oiseau_Entite CreerOiseau(Oiseau_Entite pOiseau)
        {
            this._MessageErreur = string.Empty;
            Oiseau_Entite retour = new Oiseau_Entite();
            oiseau oiseauDB = new oiseau();
            oiseauDB.Convertir(pOiseau);
            try
            {
                retour = database.InsertOiseau(oiseauDB);
            }

            catch (Exception ex)
            {
                retour.MessageErreur = ex.Message;
                this._MessageErreur = ex.Message;
            }
            return retour;
        }

        public bool SupprimerOiseau(string pUserName)
        {
            this._MessageErreur = string.Empty;
            bool retour = false;
            try
            {
                retour = database.DeleteOiseau(pUserName);
            }
            catch (Exception ex)
            {

                this._MessageErreur = ex.Message;
            }
            return retour;
        }

        public bool SupprimerOiseau(int pID)
        {

            this._MessageErreur = string.Empty;
            bool retour = false;
            try
            {
                retour = database.DeleteOiseau(pID);
            }
            catch (Exception ex)
            {
                this._MessageErreur = ex.Message;
            }
            return retour;
        }

        public Oiseau_Entite ObtenirOiseau(int pID)
        {

            return database.GetOiseau(pID);
        }
        #endregion

        #region " DeleteOiseau "

        public bool DeleteOiseau(int pID)
        {
            return database.DeleteOiseau(pID);
        }

        #endregion

        public Oiseau_Entite UpdateOiseau(Oiseau_Entite pOiseau)
        {
            try
            {
                return database.UpdateOiseau(pOiseau);
            }
            catch (Exception ex)
            {
                pOiseau.MessageErreur = ex.Message;
                return pOiseau;
            }
        }
#endregion


        #region " Photo "

        #region " GetPhoto "
        /// <summary>
        /// Obtient un Photo à partir de son ID
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        public Photo_Entite GetPhoto(int pID)
        {
            Photo_Entite retour = new Photo_Entite();
            try
            {

                retour = database.GetPhoto(pID);
            }
            catch (Exception ex)
            {
                retour.MessageErreur = ex.Message;
                this._MessageErreur = ex.Message;
            }
            return retour;
        }

        
        #endregion

        #region " CreerPhoto "
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pPhoto"></param>
        /// <returns></returns>
        public Photo_Entite CreerPhoto(Photo_Entite pPhoto)
        {
            Photo_Entite retour = new Photo_Entite();
            this._MessageErreur = string.Empty;
            photo Photo = new photo();
            Photo.Convertir(pPhoto);

            try
            {
                retour = database.InsertPhoto(Photo);
            }

            catch (Exception ex)
            {
                retour.MessageErreur = ex.Message;
                this._MessageErreur = ex.Message;
            }
            return retour;
        }

       public bool SupprimerPhoto(int pID)
        {

            this._MessageErreur = string.Empty;
            bool retour = false;
            try
            {
                retour = database.DeletePhoto(pID);
            }
            catch (Exception ex)
            {
                this._MessageErreur = ex.Message;
            }
            return retour;
        }

        public Photo_Entite ObtenirPhoto(int pID)
        {

            return database.GetPhoto(pID);
        }
        #endregion

        #region " DeletePhoto "

        public bool DeletePhoto(int pID)
        {


            return database.DeletePhoto(pID);
        }

        #endregion

        public Photo_Entite UpdatePhoto(Photo_Entite pPhoto)
        {
            try
            {
                return database.UpdatePhoto(pPhoto);
            }
            catch (Exception ex)
            {
                pPhoto.MessageErreur = ex.Message;
                return pPhoto;
            }
        }
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
