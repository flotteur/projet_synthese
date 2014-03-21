using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BO_Synthese.DTO
{
    /// <summary>
    /// Usager pour le service des observations
    /// </summary>
    [DataContract]
    public class UsagerDTO
    {
        /// <summary>
        /// Id usager
        /// </summary>
        [DataMember(Name = "ID")]
        public int ID { get; set; }

        /// <summary>
        /// Nom usager
        /// </summary>
        [DataMember(Name = "Nom")]
        public string Nom { get; set; }

        /// <summary>
        /// Prénom Usager
        /// </summary>
        [DataMember(Name = "NomUsager")]
        public string NomUsager { get; set; }
    }
}
