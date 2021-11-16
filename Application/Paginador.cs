using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public abstract class Paginador<T> where T : class 
    {
        public int TotalPaginas { get; private set; }

        private IList<T> Lista { get; set; }

        public int QuantidadePaginas { get; private set; }

        public int QuantidadeDeRegistrosPorPagina { get; private set; }

        private int PaginaAtual { get; set; }

        public IEnumerable<T> TotalDeRegistros { get;private set; }

        public Paginador(IList<T> pLista, int paginaAtual,int quantidadeRegistroPorPagina)
        {
            Lista                           = pLista;
            PaginaAtual                     = paginaAtual;
            TotalPaginas                    = pLista.Count;
            QuantidadeDeRegistrosPorPagina  = quantidadeRegistroPorPagina;
            QuantidadePaginas               = CalcularTotalDePaginas();
            TotalDeRegistros                = CalcularTotalDeRegistros();
        }

        private int CalcularTotalDePaginas()
        {

            return Lista.Count / QuantidadeDeRegistrosPorPagina;
        }

        private IList<T> CalcularTotalDeRegistros()
        {
            int registroInicial = PaginaAtual * QuantidadeDeRegistrosPorPagina;

            return  Lista.Skip(registroInicial)
                         .Take(QuantidadeDeRegistrosPorPagina)
                         .ToList();
        }

        
    }
}
