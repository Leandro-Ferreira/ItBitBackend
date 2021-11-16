using ITBIT.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class UsuarioPaginador : Paginador<UsuarioResponse>
    {
        public UsuarioPaginador(IList<UsuarioResponse> pLista, int paginaAtual, int quantidadeRegistroPorPagina) : base(pLista, paginaAtual, quantidadeRegistroPorPagina)
        {
        }
    }
}
