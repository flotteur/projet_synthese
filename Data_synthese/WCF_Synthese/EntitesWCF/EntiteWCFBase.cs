using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;

namespace WCF_Synthese.EntitesWCF
{

    public class EntiteWCFBase
    {
        public string ToJSON()
        {

            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(this.GetType());
            serializer.WriteObject(stream, this );
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            
            return reader.ReadToEnd();
        }
    }
}