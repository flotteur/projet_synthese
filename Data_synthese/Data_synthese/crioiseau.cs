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
    
    public partial class crioiseau
    {
        public int Id { get; set; }
        public byte[] Son { get; set; }
        public string Description { get; set; }
        public int IDOiseau { get; set; }
    
        public virtual oiseau oiseaux { get; set; }
    }
}