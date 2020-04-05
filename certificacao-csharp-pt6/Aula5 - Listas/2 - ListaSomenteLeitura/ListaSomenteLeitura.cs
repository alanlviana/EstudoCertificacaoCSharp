using certificacao_csharp_pt6.Aula1;
using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Linq;

namespace certificacao_csharp_pt6.Aula5
{
    class ListaSomenteLeitura : IExecutavel
    {
        public void Executar()
        {
            var loja = LojaFilmes.ObterLojaFilmes();

            foreach (var filme in loja.Filmes)
            {
                Console.WriteLine(filme.Titulo);
            }

            foreach (var filme in loja.Filmes)
            {
                Console.WriteLine(filme.Titulo);
            }

        }


    }


}
