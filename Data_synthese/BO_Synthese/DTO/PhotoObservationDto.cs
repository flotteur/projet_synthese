using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BO_Synthese.DTO
{
    [DataContract]
    public class PhotoObservationDTO
    {
        #region property
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "Photo")]
        public byte[] Image { get; set; }

        [DataMember(Name = "Description")]
        public string Description { get; set; }

        [DataMember(Name = "IdObservation")]
        public int IDObservation { get; set; }

        [DataMember(Name = "ImageMiniature")]
        public byte[] ImageMiniature { get; set; }

        [DataMember(Name = "Commentaire")]
        public string Commentaire { get; set; }

        [DataMember(Name = "ImageUpload")]
        public Stream ImageUpload { get; set; }
        #endregion

        #region public
        /// <summary>
        /// Permet de vérifier si l'image est valide avant l'insertion
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            if (IDObservation < 0)
                return false;
            if (Description == null)
                return false;
            if (Image.Length < 1)
                return false;

            return true;
        }
        #endregion
    }
}
