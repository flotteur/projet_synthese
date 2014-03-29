using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entites_Synthese
{
    public class CriOiseau_Entite: EntiteBase
    {
        public int ID { get; set; }
        public int IDOiseau { get; set; }
        public byte[] Son { get; set; }
        public String Description { get; set; }
        public string Path { get; set; }


        #region " Validations "

        /// <summary>
        /// Valide si toutes les informtions requises sont là pour créer un usager
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            return IsValid = ((this.IDOiseau >0 ) &&
                (this.Son !=null && this.Son.Length > 100));
        }
        #endregion
    }
}