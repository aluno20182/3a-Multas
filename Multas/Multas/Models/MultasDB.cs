using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Multas.Models
{
    public class MultasDB : DbContext
    {

        // identificar qual o SGBD a usar
        public MultasDB() : base("MultasDBConnectionString") { }

        // definir as tabelas da BD
        public DbSet<Condutores> Condutores { get; set; }
        public DbSet<Viaturas> Viaturas { get; set; }
        public DbSet<Agentes> Agentes { get; set; }
        public DbSet<Multas> Multas { get; set; }

        // método a ser executado no início da criação do Modelo
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // eliminar a convenção de atribuir automaticamente o 'on Delete Cascade' nas FKs
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }







    }
}