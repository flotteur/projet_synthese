using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Data_synthese.Classes
{
    interface IObservation
    {
        [DataMember(Name = "Id")]
        int Id { set; get; }
        [DataMember(Name = "DateObservation")]
        DateTime DateObservation { set; get; }
        //[DataMember(Name = "Position")]
        //string Position { set; get; }
        [DataMember(Name = "IDUsager")]
        int IDUsager { set; get; }
        [DataMember(Name = "IDOiseau")]
        int IDOiseau { set; get; }
    }
}
