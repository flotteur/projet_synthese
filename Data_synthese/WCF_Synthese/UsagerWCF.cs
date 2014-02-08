using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace WCF_Synthese
{
    // Use a data contract as illustrated in the sample below to add composite types to service operations.

    [DataContract]
    public class UsagerWCF
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string NomUsager { get; set; }
        [DataMember]
        public string MotDePasse { get; set; }
        [DataMember]
        public string Hash { get; set; }
        [DataMember]
        public bool EstAdministrateur { get; set; }
        [DataMember]
        public String Courriel { get; set; }
    }
}
