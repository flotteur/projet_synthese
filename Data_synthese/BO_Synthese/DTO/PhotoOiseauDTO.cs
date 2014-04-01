using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BO_Synthese.DTO
{
    [DataContract]
    public class PhotoOiseauDTO
    {
        #region property
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "Photo")]
        public byte[] Image { get; set; }
        #endregion

    }
}
