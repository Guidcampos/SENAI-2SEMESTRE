using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class PresencaEventoRepository : IPresencaEventoRepository
    {

        private readonly EventContext _eventContext;

        public PresencaEventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, PresencaEvento presencaEvento)
        {
            throw new NotImplementedException();
        }

        public PresencaEvento BuscarPorId(Guid id)
        {
            try
            {
                PresencaEvento presencaEventotbuscada = _eventContext.PresencaEvento.FirstOrDefault(a => a.IdPresencaEvento == id)!;
                return presencaEventotbuscada;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(PresencaEvento presencaEvento)
        {
            try
            {
                _eventContext.PresencaEvento.Add(presencaEvento);
                _eventContext.SaveChanges();
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
                PresencaEvento presencaEventoBuscado = _eventContext.PresencaEvento.Find(id)!;
                if (presencaEventoBuscado != null)
                {
                    _eventContext.PresencaEvento.Remove(presencaEventoBuscado);
                }

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PresencaEvento> Listar()
        {
            return _eventContext.PresencaEvento.ToList();
        }

    }
}