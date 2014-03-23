using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Entites_Synthese
{
    public class Photo_Entite : EntiteBase
    {
        public int ID { get; set; }
        public int IDOiseau { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }

        public override bool Validate()
        {
            return IsValid = ((this.IDOiseau > 0) &&
                (this.Image != null && this.Image.Length > 100));
        }
        
    }


}