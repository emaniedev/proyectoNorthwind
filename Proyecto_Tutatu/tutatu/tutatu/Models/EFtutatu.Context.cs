﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tutatu.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class tutatuEF : DbContext
    {
        public tutatuEF()
            : base("name=tutatuEF")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<comentario> comentario { get; set; }
        public virtual DbSet<empresa> empresa { get; set; }
        public virtual DbSet<noticia> noticia { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tatuador> tatuador { get; set; }
        public virtual DbSet<tatuaje> tatuaje { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }
        public virtual DbSet<webuser> webuser { get; set; }
        public virtual DbSet<zona> zona { get; set; }
    }
}