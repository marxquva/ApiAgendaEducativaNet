using Microsoft.EntityFrameworkCore;
using ApiAgendaEducativaNet.Models.Entities;

namespace ApiAgendaEducativaNet.Data.Context
{
    public class AplicacionDbContext : DbContext
    {
        // Constructor con opciones inyectadas por DI
        public AplicacionDbContext(DbContextOptions<AplicacionDbContext> options)
            : base(options)
        {
        }

        // DbSets representan tablas de la BD
        public DbSet<TipoEmpresa> TipoEmpresas { get; set; }
        public DbSet<Empresa> Empresas { get; set; }

        // Configuración adicional del modelo (opcional)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ejemplo: configurar nombres de tablas explícitos
            modelBuilder.Entity<TipoEmpresa>().ToTable("sis_tipo_empresa");
            modelBuilder.Entity<Empresa>().ToTable("sis_empresa");
        }
    }
}
