using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entites_Synthese
{
    public class Alerte_Entite : EntiteBase
    {
        public int ID { get; set; }
        public int IDUsager { get; set; }
        public int IDOiseau { get; set; }

        
        public Usager_Entite Usager{ get; set; }
        public Oiseau_Entite Oiseau { get;set; }

        public override bool Validate() {

            this.IsValid = ((this.IDOiseau > 0) &&
            (this.IDUsager > 0));


            return this.IsValid;
        }
    }
}
