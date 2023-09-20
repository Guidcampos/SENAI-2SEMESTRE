using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext _eventContext;

        public InstituicaoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, Instituicao instituicao)
        {
            throw new NotImplementedException();
        }

        public Evento BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Instituicao instituicao)
        {
            try
            {
                _eventContext.Instituicao.Add(instituicao);
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
               Instituicao intBuscado = _eventContext.Instituicao.Find(id)!;
                if (intBuscado != null)
                {
                    _eventContext.Instituicao.Remove(intBuscado);
                }

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Instituicao> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
