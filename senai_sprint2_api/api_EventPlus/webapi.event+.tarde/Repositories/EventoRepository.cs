using Microsoft.AspNetCore.Http.HttpResults;
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
            Evento eventoBuscado = _eventContext.Evento.Find(id)!;

            if (eventoBuscado != null)
            {
                eventoBuscado.DataEvento = evento.DataEvento;
                eventoBuscado.NomeEvento = evento.NomeEvento;
                eventoBuscado.Descricao = evento.Descricao;
                eventoBuscado.IdTipoEvento = evento.IdTipoEvento;
                eventoBuscado.IdInstituicao = evento.IdInstituicao;

                _eventContext.Update(eventoBuscado);
                _eventContext.SaveChanges();

            }
        }

        public Evento BuscarPorId(Guid id)
        {
            try
            {
                Evento eventobuscado = _eventContext.Evento.Select(e => new Evento
                {
                    IdEvento = e.IdEvento,
                    DataEvento = e.DataEvento,
                    NomeEvento = e.NomeEvento,
                    Descricao = e.Descricao,
                    IdTipoEvento = e.IdTipoEvento,
                    IdInstituicao = e.IdInstituicao,

                    TipoEvento = new TipoEvento
                    {
                        IdTipoEvento = e.IdTipoEvento,
                        Titulo = e.TipoEvento!.Titulo,
                    },

                    Instituicao = new Instituicao
                    {
                        IdInstituicao = e.IdInstituicao,
                        CNPJ = e.Instituicao!.CNPJ,
                        Endereco = e.Instituicao.Endereco,
                        NomeFantasia = e.Instituicao.NomeFantasia,

                    }

                }).FirstOrDefault(a => a.IdEvento == id)!;
                return eventobuscado;

            }
            catch (Exception)
            {

                throw;
            }
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
            try
            {
                Evento eventoBuscado = _eventContext.Evento.Find(id)!;
                if (eventoBuscado != null)
                {
                    _eventContext.Evento.Remove(eventoBuscado);
                }

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Evento> Listar()
        {
            return _eventContext.Evento.Select(e => new Evento
            {
                IdEvento = e.IdEvento,
                DataEvento = e.DataEvento,
                NomeEvento = e.NomeEvento,
                Descricao = e.Descricao,
                IdTipoEvento = e.IdTipoEvento,
                IdInstituicao = e.IdInstituicao,

                TipoEvento = new TipoEvento
                {
                    IdTipoEvento = e.IdTipoEvento,
                    Titulo = e.TipoEvento!.Titulo,
                },

                Instituicao = new Instituicao
                {
                    IdInstituicao = e.IdInstituicao,
                    CNPJ = e.Instituicao!.CNPJ,
                    Endereco = e.Instituicao.Endereco,
                    NomeFantasia = e.Instituicao.NomeFantasia,

                }
            }).ToList();

        }
    }
}
