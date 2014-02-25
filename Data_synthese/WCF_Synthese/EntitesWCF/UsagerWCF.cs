using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace WCF_Synthese.EntitesWCF
{
    // Use a data contract as illustrated in the sample below to add composite types to service operations.

    [DataContract]
    public class UsagerWCF :IExtensibleDataObject
    {
        [DataMember(Name = "ID")]
        public int ID { get; set; }
        [DataMember(Name = "NomUsager")]
        public string NomUsager { get; set; }
        [DataMember(Name = "MotDePasse")]
        public string MotDePasse { get; set; }
        [DataMember(Name = "Hash")]
        public string Hash { get; set; }
        [DataMember(Name = "EstAdministrateur")]
        public bool EstAdministrateur { get; set; }
        [DataMember(Name = "Courriel")]
        public String Courriel { get; set; }

        public ExtensionDataObject ExtensionData{get;set;}
       
    }
}
