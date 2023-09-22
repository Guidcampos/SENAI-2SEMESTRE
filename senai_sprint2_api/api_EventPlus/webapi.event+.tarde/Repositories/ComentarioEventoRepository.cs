using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {

        private readonly EventContext _eventContext;

        public ComentarioEventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, ComentarioEvento comentarioEvento)
        {

            ComentarioEvento comentarioEventoBuscado = _eventContext.ComentarioEvento.Find(id)!;

            if (comentarioEventoBuscado != null)
            {
                comentarioEventoBuscado.Texto = comentarioEvento.Texto;
                comentarioEventoBuscado.Exibe = comentarioEvento.Exibe;
                comentarioEventoBuscado.IdEvento= comentarioEvento.IdEvento;
                comentarioEventoBuscado.IdUsuario = comentarioEvento.IdUsuario;


            }
            _eventContext.Update(comentarioEventoBuscado!);

            _eventContext.SaveChanges();
        }

        public ComentarioEvento BuscarPorId(Guid id)
        {
            try
            {

                ComentarioEvento comentarioEventoBuscado = _eventContext.ComentarioEvento.FirstOrDefault(u => u.IdComentarioEvento == id)!;

                return comentarioEventoBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            try
            {
                _eventContext.ComentarioEvento.Add(comentarioEvento);
                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            ComentarioEvento comentarioEventoFind = _eventContext.ComentarioEvento.Find(id)!;

            if (comentarioEventoFind != null)
            {
                _eventContext.ComentarioEvento.Remove(comentarioEventoFind);
            }

            _eventContext.SaveChanges();
        }

        public List<ComentarioEvento> Listar()
        {
            return _eventContext.ComentarioEvento.Select(a => new ComentarioEvento
            {
                IdComentarioEvento = a.IdComentarioEvento,
                Texto = a.Texto,
                Exibe = a.Exibe,
                IdEvento= a.IdEvento,
                IdUsuario= a.IdUsuario,

                Evento = new Evento
                {

                    IdEvento = a.IdEvento,
                    DataEvento = a.Evento!.DataEvento,
                    NomeEvento = a.Evento.NomeEvento,
                    Descricao = a.Evento.Descricao,
                    IdTipoEvento = a.Evento.IdTipoEvento,
                    IdInstituicao = a.Evento.IdInstituicao,

                    TipoEvento = new TipoEvento
                    {
                        IdTipoEvento = a.Evento.IdTipoEvento,
                        Titulo = a.Evento.TipoEvento!.Titulo,
                    },

                    Instituicao = new Instituicao
                    {
                        IdInstituicao = a.Evento.IdInstituicao,
                        CNPJ = a.Evento.Instituicao!.CNPJ,
                        Endereco = a.Evento.Instituicao.Endereco,
                        NomeFantasia = a.Evento.Instituicao.NomeFantasia,

                    }
                },

                Usuario = new Usuario
                {
                    IdUsuario = a.Usuario!.IdUsuario,
                    Nome = a.Usuario.Nome,
                    Email = a.Usuario.Email,
                    IdTipoUsuario = a.Usuario.IdTipoUsuario,

                    TipoUsuario = new TipoUsuario
                    {
                        IdTipoUsuario = a.Usuario.IdTipoUsuario,
                        Titulo = a.Usuario.TipoUsuario!.Titulo,
                    }
                }




            }).ToList();
        }
    }
}
