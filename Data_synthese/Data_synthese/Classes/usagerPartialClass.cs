using System;
using System.Collections.Generic;
using System.Linq;
using Entites_Synthese ;

namespace Data_synthese
{
    public partial class usager
    {

        public Usager_Entite Convertir()
        {
            Usager_Entite retour = new Usager_Entite(){
             ID = this.Id,
             Nom = this.Nom,
             NomUsager = this.NomUsager,
             MotDePasse = this.MotPasse,
             EstAdministrateur = this.Administrateur,
             Courriel = this.Courriel ,
             
            };
            
            return retour;
        }

        public void Convertir(Usager_Entite  pUsagerEnt )
        {
            
            Id = pUsagerEnt.ID;
            Nom = pUsagerEnt.Nom;
            NomUsager = pUsagerEnt.NomUsager;
            MotPasse = pUsagerEnt.MotDePasse;
            Administrateur = pUsagerEnt.EstAdministrateur;
            Courriel = pUsagerEnt.Courriel;
            
        }
    }
}
