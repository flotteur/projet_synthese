using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entites_Synthese;
using Data_synthese;

namespace BO_Synthese
{
    class Utilitaires
    {


        #region " Utilitaires "


        #region " ConvertirEnUsagerEntite "
        /// <summary>
        /// Convertit une entité Usager en Usager_Entite
        /// </summary>
        /// <param name="pUsager"></param>
        /// <returns></returns>
        public static Usager_Entite ConvertirEnUsagerEntite(usager pUsager)
        {

            Usager_Entite retour = new Usager_Entite
            {
                ID = pUsager.Id,
                Courriel = pUsager.Courriel,
                EstAdministrateur = pUsager.Administrateur,
                MotDePasse = pUsager.MotPasse,
                Nom = pUsager.Nom,
                NomUsager = pUsager.NomUsager
            };

            return retour;
        }

        /// <summary>
        /// Convertit une entité Usager_Entite en usager
        /// </summary>
        /// <returns></returns>
        public usager ConvertirEnUsager( Usager_Entite pUser )
        {

            usager retour = new usager
            {
                Id = pUser.ID,
                Courriel = pUser.Courriel,
                Administrateur = pUser.EstAdministrateur,
                MotPasse = pUser.MotDePasse,
                Nom = pUser.Nom,
                NomUsager = pUser.NomUsager
            };

            return retour;
        }
        #endregion

        #endregion
    }
}
