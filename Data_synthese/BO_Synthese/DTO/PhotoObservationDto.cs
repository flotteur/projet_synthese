using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BO_Synthese.DTO
{
    [DataContract]
    public class PhotoObservationDTO
    {
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
    }
}
