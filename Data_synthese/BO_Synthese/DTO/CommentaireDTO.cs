using System;
using System.Collections.Generic;
using System.Globalization;
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

        /// <summary>
        /// Date formattée du commentaire pour envoyer au service web
        /// </summary>
        [DataMember(Name = "Date")]
        public string Date {get;set;}

        /// <summary>
        ///  Date pour la bd
        /// </summary>
        public DateTime DateBd { get; set; }

        /// <summary>
        /// Permet de traiter la date avant l'envoi au client
        /// </summary>
        /// <param name="ctx"></param>
        [OnSerializing]
        void OnSerializing(StreamingContext ctx)
        {
            if (DateBd != null)
            {
                Date = DateBd.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Permet de traiter la date
        /// </summary>
        /// <param name="ctx"></param>
        [OnDeserializing]
        void OnDeserializing(StreamingContext ctx)
        {
            Date = "1900-01-01";
        }

        //[OnDeserialized]
        //void OnDeserialized(StreamingContext ctx)
        //{
        //    DateBd = DateTime.ParseExact(Date,
        //        "yyyy-MM-dd HH:mm:ss",
        //        CultureInfo.InvariantCulture);
        //
        //}

        #endregion
    }
}