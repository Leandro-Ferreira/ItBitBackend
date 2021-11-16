using ITBIT.CORE.Entidades;
using System.Collections.Generic;

namespace ITBIT.CORE.Repositorio
{
    public interface IRepositorioUsuario
    {
       void Salvar(Usuario usuario);

       void Editar(Usuario usuario);

       void Excluir(int id);

       IEnumerable<Usuario> GetUsuario();

       IEnumerable<Usuario> GetUsuario(string nome);

       Usuario GetUsuario(int id);

    }
}
