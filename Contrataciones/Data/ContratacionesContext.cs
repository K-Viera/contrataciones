using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Contrataciones.Models;

namespace Contrataciones.Data
{
    public class ContratacionesContext : DbContext
    {
        public ContratacionesContext (DbContextOptions<ContratacionesContext> options)
            : base(options)
        {
        }
        public DbSet<Trabajador> Trabajadores { get; set; }
        public DbSet<Contrato> Contratos { get; set; }

        public DbSet<Contrataciones.Models.Trabajador> Trabajador { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trabajador>().ToTable("Trabajador");
            modelBuilder.Entity<Contrato>().ToTable("Contrato");
        }
    }
}
