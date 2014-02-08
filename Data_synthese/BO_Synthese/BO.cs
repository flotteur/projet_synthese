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
        #region Session
        /// <summary>
        /// Classe privée qui contient les informations sur la session courante
        /// </summary>
        /// 
        private class  Session{
            public static string PasswordHash { get;  set; }
            public static string UserName { get;  set; }
            public static int UserID{get;set;}

            
        }
#endregion 
        private DatabaseObject database = new DatabaseObject();


        #region " Méthodes privées "

        private void InitialiseSession(Usager_Entite pUsager)
        {

            Session.PasswordHash = Encription.GetHash(pUsager.MotDePasse);
            Session.UserName = pUsager.NomUsager;
            Session.UserID = pUsager.ID;
        }

        #endregion


        #region " Méthodes publiques "
        public Usager_Entite Getusager(int pID) {
        
            return database.GetUsager(pID);
        }

#endregion

        public void Dispose()
        {
            database.Dispose();
        }
    }
}
