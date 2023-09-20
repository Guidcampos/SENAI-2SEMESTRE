using Microsoft.EntityFrameworkCore;
using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Contexts
{
    public class EventContext : DbContext
    {

        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<TipoEvento> TipoEvento { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<ComentarioEvento> ComentarioEvento { get; set; }
        public DbSet<PresencaEvento> PresencaEvento { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = NOTE10-S15; Database = Event+_webapi_tarde; User Id = sa; Password = Senai@134; TrustServerCertificate = True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
