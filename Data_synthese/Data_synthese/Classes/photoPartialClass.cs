using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entites_Synthese;

namespace Data_synthese
{
    public partial class photo
    {
        public void Convertir( Photo_Entite pPhoto ){
        
            this.Id = pPhoto.ID;
            this.Description = pPhoto.Description;
            this.IDOiseau = pPhoto.IDOiseau;
            this.Image = pPhoto.Image;
            this.Path = pPhoto.Path;
        }
        public Photo_Entite Convertir() {
            Photo_Entite retour = new Photo_Entite() { ID = this.Id,
                                                       Description = this.Description,
                                                       IDOiseau = this.IDOiseau,
                                                       Image = this.Image,
            Path = this.Path};


            return retour;
        }
    }
}
