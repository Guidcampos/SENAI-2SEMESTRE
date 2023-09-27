using HealthClinic_tarde.Contexts;
using HealthClinic_tarde.Domains;
using HealthClinic_tarde.Interfaces;

namespace HealthClinic_tarde.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    { 


        private readonly HealthContext _healthcontext;

        public TipoUsuarioRepository()
        {
            _healthcontext = new HealthContext();
        }
        
        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {

            _healthcontext.Add(tipoUsuario);
            _healthcontext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TipoUsuario> Listar()
        {
            return _healthcontext.TipoUsuario.ToList();
        }
    }
}

