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

        [DataMember(Name = "ImageUpload")]
        public string ImageUpload { get; set; }

        [DataMember(Name = "Description")]
        public string Description { get; set; }

        [DataMember(Name = "IdObservation")]
        public int IDObservation { get; set; }

        [DataMember(Name = "Path")]
        public string Path { get; set; }
        //[DataMember(Name = "ImageMiniature")]
        //public byte[] ImageMiniature { get; set; }

        //[DataMember(Name = "Commentaire")]
        //public string Commentaire { get; set; }

        /// <summary>
        /// Permet de traiter la date avant l'envoi au client
        /// </summary>
        /// <param name="ctx"></param>
        [OnSerializing]
        void OnSerializing(StreamingContext ctx)
        {
            //DateObservationForSerialization = DateObservation.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Permet de traiter la date
        /// </summary>
        /// <param name="ctx"></param>
        [OnDeserializing]
        void OnDeserializing(StreamingContext ctx)
        {
            //DateObservationForSerialization = "1900-01-01";
        }

        [OnDeserialized]
        void OnDeserialized(StreamingContext ctx)
        {
            //DateObservation = DateTime.ParseExact(DateObservationForSerialization,
            //    "yyyy-MM-dd HH:mm:ss",
            //    CultureInfo.InvariantCulture);
            Image = Convert.FromBase64String(ImageUpload);
        }

        //[DataMember(Name = "ImageUpload")]
        //public Stream ImageUpload { get; set; }
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
            //if (Description == null)
            //    return false;
            if (Image.Length < 1)
                return false;

            return true;
        }
        #endregion
    }
}
