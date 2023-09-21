using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly EventContext _eventContext;

        public TipoEventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, TipoEvento tipoEvento)
        {
            TipoEvento tipoEventoBuscado = _eventContext.TipoEvento.Find(id)!;

            if (tipoEventoBuscado != null)
            {
                tipoEventoBuscado.Titulo = tipoEvento.Titulo;

            }
            _eventContext.Update(tipoEventoBuscado!);

            _eventContext.SaveChanges();
        }

        public TipoEvento BuscarPorId(Guid id)
        {
            try
            {
                TipoEvento tipoEventoBusc = _eventContext.TipoEvento.FirstOrDefault(a => a.IdTipoEvento == id)!;
                return tipoEventoBusc;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(TipoEvento tipoEvento)
        {
            try
            {
                _eventContext.TipoEvento.Add(tipoEvento);
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
                TipoEvento tipoEventoBuscado = _eventContext.TipoEvento.Find(id)!;
                if (tipoEventoBuscado != null)
                {
                    _eventContext.TipoEvento.Remove(tipoEventoBuscado);
                }

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TipoEvento> Listar()
        {
            return _eventContext.TipoEvento.ToList();
        }
    }
}
