using HealthClinic_tarde.Contexts;
using HealthClinic_tarde.Domains;
using HealthClinic_tarde.Interfaces;

namespace HealthClinic_tarde.Repositories
{
    public class ProntuarioRepository : IProntuarioRepository
    {
        private readonly HealthContext _healthcontext;

        public ProntuarioRepository()
        {
            _healthcontext = new HealthContext();
        }

        public void Atualizar(Guid id, Prontuario prontuario)
        {
            throw new NotImplementedException();
        }

        public Prontuario BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Prontuario prontuario)
        {
            try
            {
                _healthcontext.Prontuario.Add(prontuario);
                _healthcontext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Prontuario prontuarioBuscado = _healthcontext.Prontuario.FirstOrDefault(a => a.IdProntuario == id)!;
                if (prontuarioBuscado != null)
                {
                    _healthcontext.Remove(prontuarioBuscado);
                    _healthcontext.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Prontuario> Listar()
        {
            return _healthcontext.Prontuario.ToList();
        }
    }
}
