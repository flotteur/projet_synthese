using System;
using System.Collections.Generic;
using System.Linq;
using Entites_Synthese;

namespace Data_synthese
{
    public partial class alerte
    {

        public Alerte_Entite Convertir(){
        
            Alerte_Entite retour = new Alerte_Entite() { ID= this.Id,            
            IDOiseau = this.IDOiseau ,
            IDUsager = this.IDUsager,
            Oiseau = this.oiseaux.Convertir(),
            Usager = this.usager.Convertir()
            };

            return retour;
        }

        public void  Convertir( Alerte_Entite pAlerteEnt)
        {
                       
            Id = pAlerteEnt.ID;
            IDOiseau = pAlerteEnt.IDOiseau;
            IDUsager = pAlerteEnt.IDUsager;

            
        }
    }
}
