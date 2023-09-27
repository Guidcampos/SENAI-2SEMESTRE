using HealthClinic_tarde.Contexts;
using HealthClinic_tarde.Domains;
using HealthClinic_tarde.Interfaces;

namespace HealthClinic_tarde.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HealthContext _healthcontext;

        public MedicoRepository()
        {
            _healthcontext = new HealthContext();
        }
        public void Atualizar(Guid id, Medico medico)
        {
            throw new NotImplementedException();
        }

        public Medico BuscarPorId(Guid id)
        {
            try
            {
                Medico medicoBusc = _healthcontext.Medico.FirstOrDefault(a => a.IdMedico == id)!;
                return medicoBusc;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Medico medico)
        {
            try
            {
                _healthcontext.Add(medico);
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
                _healthcontext.Medico.Remove(BuscarPorId(id));
                _healthcontext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Medico> Listar()
        {
            return _healthcontext.Medico.ToList();
        }
    }
}
