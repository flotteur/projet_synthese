using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using Entites_Synthese;
using System.Runtime.Serialization;

namespace WCF_Synthese.EntitesWCF
{
    [DataContract]
    public class EntiteWCFBase
    {
        [DataMember(Name = "MessageErreur")]
        public string  MessageErreur { get; set; }

        public string ToJSON()
        {

            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(this.GetType());
            serializer.WriteObject(stream, this );
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            
            return reader.ReadToEnd();
        }
        public virtual Entites_Synthese.EntiteBase Convertir(){

            Entites_Synthese.EntiteBase retour = new Entites_Synthese.EntiteBase();
            
            return retour;
        }
    }
}