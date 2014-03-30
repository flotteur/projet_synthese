using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Data_synthese.Classes;
using System.Globalization;
using BO_Synthese.DTO;

namespace BO_Synthese
{
    [DataContract]
    public class ObservationDTO
    {
        #region property
        /// <summary>
        /// L'id de l'observation
        /// </summary>
        [DataMember(Name = "Id")]
        public int Id { set; get; }

        /// <summary>
        /// La date formatée pour le serivce
        /// </summary>
        [DataMember(Name = "DateObservation")]
        public string DateObservationForSerialization { get; set; }

        /// <summary>
        /// La date de l'observation
        /// </summary>
        public DateTime DateObservation { set; get; }

        /// <summary>
        /// La latitude (coord gps)
        /// </summary>
        [DataMember(Name = "Latitude")]
        public double? Latitude { set; get; }

        /// <summary>
        /// La longitude (coord gps)
        /// </summary>
        [DataMember(Name = "Longitude")]
        public double? Longitude { set; get; }

        /// <summary>
        /// L'id de l'usager
        /// </summary>
        [DataMember(Name = "IDUsager")]
        public int IDUsager { set; get; }

        /// <summary>
        /// L'id de l'oiseau
        /// </summary>
        [DataMember(Name = "IDOiseau")]
        public int IDOiseau { set; get; }

        /// <summary>
        /// L'usager de l'observation
        /// </summary>
        [DataMember(Name = "Usager")]
        public UsagerDTO Usager { get; set; }

        /// <summary>
        /// L'oiseau de l'observation
        /// </summary>
        [DataMember(Name = "Oiseau")]
        public OiseauDTO Oiseau { get; set; }

        /// <summary>
        /// Titre de l'observation
        /// </summary>
        [DataMember(Name = "Titre")]
        public string Titre { get; set; }

        /// <summary>
        /// Texte de détail de l'observation
        /// </summary>
        [DataMember(Name = "Detail")]
        public string Detail { get; set; }

        /// <summary>
        /// Permet de traiter la date avant l'envoi au client
        /// </summary>
        /// <param name="ctx"></param>
        [OnSerializing]
        void OnSerializing(StreamingContext ctx)
        {
            DateObservationForSerialization = DateObservation.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Permet de traiter la date
        /// </summary>
        /// <param name="ctx"></param>
        [OnDeserializing]
        void OnDeserializing(StreamingContext ctx)
        {
            DateObservationForSerialization = "1900-01-01";
        }

        [OnDeserialized]
        void OnDeserialized(StreamingContext ctx)
        {
            DateObservation = DateTime.ParseExact(DateObservationForSerialization,
                "yyyy-MM-dd HH:mm:ss", 
                CultureInfo.InvariantCulture);
        }
        #endregion

        #region constructor
        public ObservationDTO()
        {
            Id = 0;
        }
        #endregion
        
        #region public
        /// <summary>
        /// Vérifie si l'observation est valide
        /// </summary>
        /// <returns>True si valide</returns>
        public bool isValid()
        {
            if (IDOiseau > 1 || IDUsager > 1)
                return false;

            return true;
        }
        #endregion
    }
}
