using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BO_Synthese.DTO
{
    [DataContract]
    public class ListePhotoObservationDTO
    {
        [DataMember(Name = "IDObservation")]
        public int IDObservation{ get; set; }

        [DataMember(Name = "photoList")]
        public List<string> PhotoObservationList { get; set; }
    }
}
