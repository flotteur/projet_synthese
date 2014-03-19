using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_Synthese.EntitesWCF
{
    public class ObservationWCF
    {
        [DataMember(Name = "ID")]
        public int ID { get; set; }
        [DataMember(Name = "DateObservation")]
        public DateTime DateObservation{ get; set; }
        [DataMember(Name = "Position")]
        public string Position { get; set; }
        [DataMember(Name = "IDUsager")]
        public int IDUsager { get; set; }
        [DataMember(Name = "IDOiseau")]
        public int IDOiseau { get; set; }
    }
}