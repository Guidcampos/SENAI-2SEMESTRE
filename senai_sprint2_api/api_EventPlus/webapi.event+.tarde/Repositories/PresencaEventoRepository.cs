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
            PresencaEvento presencaEventoBuscado = _eventContext.PresencaEvento.Find(id)!;

            if (presencaEventoBuscado != null)
            {
                presencaEventoBuscado.Situacao = presencaEvento.Situacao;
                presencaEventoBuscado.IdEvento = presencaEvento.IdEvento;
                presencaEventoBuscado.IdUsuario = presencaEvento.IdUsuario;

            }

            _eventContext.Update(presencaEventoBuscado!);
            _eventContext.SaveChanges();
        }

        public PresencaEvento BuscarPorId(Guid id)
        {
            try
            {
                PresencaEvento presencaEventotbuscada = _eventContext.PresencaEvento.Select(a => new PresencaEvento
                {
                    IdPresencaEvento = a.IdPresencaEvento,
                    Situacao = a.Situacao,
                    IdEvento = a.IdEvento,
                    IdUsuario = a.IdUsuario,

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


                }
            ).FirstOrDefault(a => a.IdPresencaEvento == id)!;
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
            return _eventContext.PresencaEvento.Select(a => new PresencaEvento
            {
                IdPresencaEvento = a.IdPresencaEvento,
                Situacao = a.Situacao,
                IdEvento = a.IdEvento,
                IdUsuario = a.IdUsuario,

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


            }
            ).ToList();
        }

    }
}