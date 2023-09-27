using HealthClinic_tarde.Contexts;
using HealthClinic_tarde.Domains;
using HealthClinic_tarde.Interfaces;

namespace HealthClinic_tarde.Repositories
{
    public class EspecialidaRepository : IEspecialidadeRepository
    {
        private readonly HealthContext _healthcontext;

        public EspecialidaRepository()
        {
            _healthcontext = new HealthContext();
        }

        public void Atualizar(Guid id, Especialidade especialidade)
        {
            throw new NotImplementedException();
        }

        public Especialidade BuscarPorId(Guid id)
        {
            try
            {
                Especialidade especialidadeBusc = _healthcontext.Especialidade.FirstOrDefault(a => a.IdEspecialidade == id)!;
                return especialidadeBusc;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Especialidade especialidade)
        {
            try
            {
                _healthcontext.Add(especialidade);
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
                _healthcontext.Especialidade.Remove(BuscarPorId(id));
                _healthcontext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Especialidade> Listar()
        {
            return _healthcontext.Especialidade.ToList();
        }
    }
}
