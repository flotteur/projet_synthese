//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data_synthese
{
    using System;
    using System.Collections.Generic;
    
    public partial class Commentaire
    {
        public int Id { get; set; }
        public string Texte { get; set; }
        public int observationId { get; set; }
        public int IDUsager { get; set; }
    
        public virtual observation observation { get; set; }
        public virtual usager usager { get; set; }
    }
}