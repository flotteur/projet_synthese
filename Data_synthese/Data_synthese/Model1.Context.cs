﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class synthese_dbEntities : DbContext
    {
        public synthese_dbEntities()
            : base("name=synthese_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<alerte> alerte { get; set; }
        public DbSet<alertesusager> alertesusager { get; set; }
        public DbSet<crioiseau> crioiseau { get; set; }
        public DbSet<message> message { get; set; }
        public DbSet<observation> observation { get; set; }
        public DbSet<oiseau> oiseau { get; set; }
        public DbSet<photoobservation> photoobservation { get; set; }
        public DbSet<photo> photo { get; set; }
        public DbSet<sonobservation> sonobservation { get; set; }
        public DbSet<usager> usager { get; set; }
    }
}
