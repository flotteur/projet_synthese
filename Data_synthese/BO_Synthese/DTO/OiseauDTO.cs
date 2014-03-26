using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BO_Synthese.DTO
{
    /// <summary>
    /// Permet de définir un oiseau pour les services webs
    /// </summary>
    [DataContract]
    public class OiseauDTO
    {
        #region property
        /// <summary>
        /// L'id de l'oiseau
        /// </summary>
        [DataMember(Name = "ID")]
        public int Id;

        /// <summary>
        /// Le nom de l'espèce
        /// </summary>
        [DataMember(Name = "Espece")]
        public string Espece;

        /// <summary>
        /// Description de l'oiseau
        /// </summary>
        [DataMember(Name = "Description")]
        public string Description;
        #endregion
    }
}
