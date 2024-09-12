using Microsoft.EntityFrameworkCore;
using PassaIngressos_WebAPI.Dto;

namespace PassaIngressos_WebAPI.Database
{
    public class DbPassaIngressos : DbContext
    {
        public DbPassaIngressos(DbContextOptions<DbPassaIngressos> options): base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Pessoa> Pessoa { get; set; }

        public DbSet<Evento> Evento { get; set; }

        public DbSet<Ingresso> Ingresso { get; set; }

        public DbSet<TipoIngresso> TipoIngresso { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}