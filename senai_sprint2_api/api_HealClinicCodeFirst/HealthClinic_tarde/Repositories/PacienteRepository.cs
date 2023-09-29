using HealthClinic_tarde.Contexts;
using HealthClinic_tarde.Domains;
using HealthClinic_tarde.Interfaces;

namespace HealthClinic_tarde.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HealthContext _healthcontext;

        public PacienteRepository()
        {
            _healthcontext = new HealthContext();
        }

        public void Atualizar(Guid id, Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public Paciente BuscarPorId(Guid id)
        {
            try
            {
                Paciente pacienteBusc = _healthcontext.Paciente.FirstOrDefault(a => a.IdPaciente == id)!;
                return pacienteBusc;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Paciente paciente)
        {
            try
            {
                _healthcontext.Paciente.Add(paciente);
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
                Paciente pacienteBuscado = _healthcontext.Paciente.FirstOrDefault(a => a.IdPaciente == id)!;
                if (pacienteBuscado != null)
                {
                    _healthcontext.Remove(pacienteBuscado);
                    _healthcontext.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }


        }

        public List<Paciente> Listar()
        {
           return _healthcontext.Paciente.ToList();
        }
    }
}
