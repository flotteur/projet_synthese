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
        [DataMember(Name = "Id")]
        public int Id { set; get; }

        [DataMember(Name = "DateObservation")]
        public string DateObservationForSerialization { get; set; }

        public DateTime DateObservation { set; get; }

        //[DataMember(Name = "Position")]
        //string Position { set; get; }

        [DataMember(Name = "IDUsager")]
        public int IDUsager { set; get; }

        [DataMember(Name = "IDOiseau")]
        public int IDOiseau { set; get; }

        [DataMember(Name = "Usager")]
        public UsagerDTO usager { get; set; }

        [OnSerializing]
        void OnSerializing(StreamingContext ctx)
        {
            DateObservationForSerialization = DateObservation.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        [OnDeserializing]
        void OnDeserializing(StreamingContext ctx)
        {
            DateObservationForSerialization = "1900-01-01";
        }

        [OnDeserialized]
        void OnDeserialized(StreamingContext ctx)
        {
            DateObservation = DateTime.ParseExact(DateObservationForSerialization,
                "yyyy-MM-dd", 
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
