using System.Collections.Generic;

namespace ITBIT.CORE.Entidades
{
    public class Sexo
    {
        public int SexoId { get; private set; }

        public string Descricao { get; private set; }

        public ICollection<Usuario> Usuarios { get; private set; }

        protected Sexo() { }

        public Sexo(int pId, string pDescricao)
        {
            SexoId    = pId;
            Descricao = pDescricao;
        }
    }
}
