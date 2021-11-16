using ITBIT.CORE.DTO;
using System.Collections.Generic;

namespace ITBIT.CORE.Servico
{
    public interface IServicoUsuario
    {
        void Salvar(UsuarioRequest usuarioRequest);

        void Editar(int idUsuario);

        void Editar(UsuarioRequest usuarioRequest);

        UsuarioResponse GetUsuario(int id);

        IEnumerable<UsuarioResponse> GetUsuario(string nome);

        IEnumerable<UsuarioResponse> GetUsuario();

        void Excluir(int id);
    }
}
