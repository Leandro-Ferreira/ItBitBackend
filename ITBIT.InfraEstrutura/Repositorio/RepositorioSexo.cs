using ITBIT.CORE.Entidades;
using ITBIT.CORE.Repositorio;
using ITBIT.InfraEstrutura.Data;

namespace ITBIT.InfraEstrutura.Repositorio
{
    public class RepositorioSexo : IRepositorioSexo
    {
        protected UsuarioDBContext _usuarioDBContext;
        
        public RepositorioSexo(UsuarioDBContext usuarioDBContext)
        {
            _usuarioDBContext = usuarioDBContext;
        }

        public Sexo GetSexo(int id)
        {
            return _usuarioDBContext.Sexo.Find(id);
        }
    }
}
