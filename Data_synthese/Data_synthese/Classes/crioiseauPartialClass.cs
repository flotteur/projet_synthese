using System;
using System.Collections.Generic;
using System.Linq;
using Entites_Synthese;
namespace Data_synthese
{
    public partial class crioiseau
    {
        public CriOiseau_Entite Convertir(){
            CriOiseau_Entite retour = new CriOiseau_Entite() { Description = this.Description,
                 ID = this.Id,
                 IDOiseau =this.IDOiseau,
                 Son = this.Son,
                 Path = this.Path
            };

            return retour;
        }

        public void Convertir( CriOiseau_Entite pCriOiseau){
        
            this.Description = pCriOiseau.Description;
            this.Id = pCriOiseau.ID;
            this.IDOiseau = pCriOiseau.ID;
            this.Son = pCriOiseau.Son;
            this.Path = pCriOiseau.Path;
        }
    }
}
