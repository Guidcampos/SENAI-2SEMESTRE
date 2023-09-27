using HealthClinic_tarde.Contexts;
using HealthClinic_tarde.Domains;
using HealthClinic_tarde.Interfaces;

namespace HealthClinic_tarde.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {

        private readonly HealthContext _healthcontext;

        public ClinicaRepository()
        {
            _healthcontext = new HealthContext();
        }

        public void Atualizar(Guid id, Clinica clinica)
        {
            throw new NotImplementedException();
        }

        public Clinica BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Clinica clinica)
        {
            try
            {
                _healthcontext.Add(clinica);
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
                Clinica clinicaBuscada = _healthcontext.Clinica.FirstOrDefault(a => a.IdClinica == id)!;
                _healthcontext.Remove(clinicaBuscada);
                _healthcontext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Clinica> Listar()
        {
            return _healthcontext.Clinica.ToList();
        }
    }
}
