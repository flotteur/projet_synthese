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
    
    public partial class oiseau
    {
        public oiseau()
        {
            this.alertes = new HashSet<alerte>();
            this.crioiseaux = new HashSet<crioiseau>();
            this.observations = new HashSet<observation>();
            this.photos = new HashSet<photo>();
        }
    
        public int Id { get; set; }
        public string Espece { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<alerte> alertes { get; set; }
        public virtual ICollection<crioiseau> crioiseaux { get; set; }
        public virtual ICollection<observation> observations { get; set; }
        public virtual ICollection<photo> photos { get; set; }
    }
}
