using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BO_Synthese.DTO
{
    [DataContract]
    public class CommentaireDTO
    {
        #region property
        /// <summary>
        /// L'id du commentaire
        /// </summary>
        [DataMember(Name = "Id")]
        public int Id { set; get; }

        /// <summary>
        /// L'id de l'usager
        /// </summary>
        [DataMember(Name = "IDUsager")]
        public int IDUsager { set; get; }

        /// <summary>
        /// L'id de l'observation
        /// </summary>
        [DataMember(Name = "observationId")]
        public int observationId { set; get; }

        /// <summary>
        /// Texte du commentaire
        /// </summary>
        [DataMember(Name = "Texte")]
        public string Texte { get; set; }
        #endregion
    }
}