using Microsoft.EntityFrameworkCore;
using PassaIngressos_WebAPI.Dto;

namespace PassaIngressos_WebAPI.Database
{
    public class DbPassaIngressos : DbContext
    {
        public DbPassaIngressos(DbContextOptions<DbPassaIngressos> options): base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Ingresso> Ingressos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}