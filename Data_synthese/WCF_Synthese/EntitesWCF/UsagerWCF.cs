using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Entites_Synthese;

namespace WCF_Synthese.EntitesWCF
{
    // Use a data contract as illustrated in the sample below to add composite types to service operations.

    [DataContract]
    public class UsagerWCF : EntiteWCFBase
    {
        [DataMember(Name = "ID")]
        public int ID { get; set; }

        [DataMember(Name = "Nom")]
        public string Nom { get; set; }
        [DataMember(Name = "NomUsager")]
        public string NomUsager { get; set; }
        [DataMember(Name = "MotDePasse")]
        public string MotDePasse { get; set; }
        [DataMember(Name = "EstAdministrateur")]
        public bool EstAdministrateur { get; set; }
        [DataMember(Name = "Courriel")]
        public String Courriel { get; set; }


        #region " ConvertirEnUsagerEntite "
        /// <summary>
        /// Convertit une entité UsagerWCF en Usager_Entite
        /// </summary>
        /// <param name="pUsager"></param>
        /// <returns></returns>
        public Usager_Entite Convertir(UsagerWCF pUsager)
        {

            Usager_Entite retour = new Usager_Entite
            {
                ID = pUsager.ID,
                Courriel = pUsager.Courriel,
                EstAdministrateur = pUsager.EstAdministrateur,
                MotDePasse = pUsager.MotDePasse,
                Nom = pUsager.Nom,
                NomUsager = pUsager.NomUsager,
                MessageErreur = pUsager.MessageErreur
            };

            return retour;
        }

        /// <summary>
        /// Convertit une entité UsagerWCF en Usager_Entite
        /// </summary>
        /// <returns></returns>
        public Usager_Entite Convertir()
        {

            Usager_Entite retour = new Usager_Entite
            {
                ID = this.ID,
                Courriel = this.Courriel,
                EstAdministrateur = this.EstAdministrateur,
                MotDePasse = this.MotDePasse,
                Nom = this.Nom,
                NomUsager = this.NomUsager,
                MessageErreur = this.MessageErreur
            };

            return retour;
        }

        /// <summary>
        /// Convertit une entité Usager_Entite en UsagerWCF 
        /// </summary>
        /// <param name="pUsager"></param>
        /// <returns></returns>
        public UsagerWCF Convertir(Usager_Entite pUsager)
        {

            UsagerWCF retour = new UsagerWCF
            {
                ID = pUsager.ID,
                Courriel = pUsager.Courriel,
                EstAdministrateur = pUsager.EstAdministrateur,
                MotDePasse = pUsager.MotDePasse,
                Nom = pUsager.Nom,
                NomUsager = pUsager.NomUsager,
                MessageErreur = pUsager.MessageErreur
            };

            return retour;
        }
        #endregion
      }
}
