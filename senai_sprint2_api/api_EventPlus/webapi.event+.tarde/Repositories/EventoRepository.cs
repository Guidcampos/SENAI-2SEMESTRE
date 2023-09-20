using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext _eventContext;

        public EventoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, Evento evento)
        {
            throw new NotImplementedException();
        }

        public Evento BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Evento evento)
        {
            try
            {
                _eventContext.Evento.Add(evento);
                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Evento> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
