using HealthClinic_tarde.Contexts;
using HealthClinic_tarde.Domains;
using HealthClinic_tarde.Interfaces;

namespace HealthClinic_tarde.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {

        private readonly HealthContext _healthcontext;

        public ConsultaRepository()
        {
            _healthcontext = new HealthContext();
        }
        public void Atualizar(Guid id, Consulta consulta)
        {
            throw new NotImplementedException();
        }

        public Consulta BuscarPorId(Guid id)
        {
            try
            {
              Consulta consultaBuscada =  _healthcontext.Consulta.FirstOrDefault(a => a.IdConsulta == id)!;
                return consultaBuscada;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Consulta consulta)
        {
            try
            {
                _healthcontext.Add(consulta);
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
            _healthcontext.Consulta.Remove(BuscarPorId(id));
            _healthcontext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Consulta> Listar()
        {
            return _healthcontext.Consulta.ToList();
        }
    }
}
