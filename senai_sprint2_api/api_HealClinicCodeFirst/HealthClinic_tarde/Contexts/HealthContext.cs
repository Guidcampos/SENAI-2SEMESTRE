using HealthClinic_tarde.Domains;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic_tarde.Contexts
{
    public class HealthContext : DbContext
    {

        public DbSet<Clinica> Clinica { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Prontuario> Prontuario { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = NOTE10-S15; Database = HealthClinic_tarde; User Id = sa; Password = Senai@134; TrustServerCertificate = True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
