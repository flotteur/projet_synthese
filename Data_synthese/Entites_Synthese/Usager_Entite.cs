using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entites_Synthese
{
    public class Usager_Entite
    {
        public int ID { get; set; }
        public string NomUsager { get; set; }
        public string MotDePasse { get; set; }
        public string Hash { get; set; }
        public bool  EstAdministrateur { get; set; }
        public String Courriel { get; set; }

        #region " Constructeurs "

        public Usager_Entite(int pID,
        string pNomUsager,
        string pMotDePasse,
        bool pEstAdministrateur,
        String pCourriel) {

            this.ID = pID;
            this.NomUsager = pNomUsager;
            this.MotDePasse = pMotDePasse;
            this.EstAdministrateur = pEstAdministrateur;
            this.Courriel = pCourriel;
            
        }

        public Usager_Entite() {

        }

        #endregion

    }
}
