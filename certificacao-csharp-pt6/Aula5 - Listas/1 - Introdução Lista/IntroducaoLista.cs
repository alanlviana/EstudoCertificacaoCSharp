using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;

namespace certificacao_csharp_pt6.Aula5
{
    class IntroducaoLista : IExecutavel
    {
        public void Executar()
        {
            var esperanca = new Filme("Episódio IV - Uma nova esperança", 1977);
            var imperio = new Filme("Episódio V - Império contra-ataca", 1980);
            var retorno = new Filme("Episódio VI - O Retorno Jedi", 1983);
            var ameaca = new Filme("Episódio I - A ameaça Fantasma", 1999);
            var ataque = new Filme("Episódio II - Ataque dos Clones", 2002);
            var guerraClones = new Filme("A guerra dos clones", 2003);
            var vinganca = new Filme("Episódio III - A vingança dos Sith", 2005);
            var rebels = new Filme("Rebels", 2014);
            var despertar = new Filme("Episódio VII - O despertar da força", 2015);
            var rogue = new Filme("Rogue one", 2016);
            var ultimo = new Filme("Episódio VIII: Os últimos Jedi", 2017);

            var listaStarWars = new List<Filme>();

            //
            Console.WriteLine("Tamanho da lista:" + listaStarWars.Count);
            Console.WriteLine("Capacidade da lista:" + listaStarWars.Capacity); //Capacidade é a quantidade e inserções possíveis sem redimencionar a lista.

            // 
            listaStarWars.AddRange(new List<Filme> { esperanca, imperio, retorno });
            ImprimirLista(listaStarWars);

            var posicao = 1;
            listaStarWars.Insert(posicao-1, ameaca);
            ImprimirLista(listaStarWars);

            posicao++;
            listaStarWars.InsertRange(posicao - 1, new [] { ataque, guerraClones, vinganca, rebels });
            ImprimirLista(listaStarWars);

            listaStarWars.Add(despertar);
            ImprimirLista(listaStarWars);

            listaStarWars.Insert(listaStarWars.IndexOf(esperanca), rogue);
            ImprimirLista(listaStarWars);

            listaStarWars.Add(ultimo);
            ImprimirLista(listaStarWars);

            listaStarWars.Reverse();
            ImprimirLista(listaStarWars);
            listaStarWars.Reverse();

            //Somente filmes com atores
            var filmesComAtoresReais = new List<Filme>(listaStarWars);
            filmesComAtoresReais.RemoveAt(5);
            filmesComAtoresReais.Remove(guerraClones);
            ImprimirLista(filmesComAtoresReais);

            var trilogiaOriginal = new List<Filme>(listaStarWars);
            trilogiaOriginal.RemoveAll(f => f.Ano > 1983);
            ImprimirLista(trilogiaOriginal);

            var filmesListaAlfabetica = new List<Filme>(filmesComAtoresReais);
            filmesListaAlfabetica.Sort();
            ImprimirLista(filmesListaAlfabetica);

            var ordemLancamento = new List<Filme>(filmesComAtoresReais);
            ordemLancamento.Sort((f1,f2) => f1.Ano.CompareTo(f2.Ano));
            ImprimirLista(ordemLancamento);

            var trilogiaInicial = new Filme[3];
            ordemLancamento.CopyTo(3, trilogiaInicial, 0, 3);
            ImprimirLista(trilogiaInicial);

        }

        private void ImprimirLista(IEnumerable<Filme> listaStarWars)
        {
            Console.WriteLine("Imprimir lista:");
            foreach (var filme in listaStarWars)
            {
                Console.WriteLine(filme);
            }
            Console.WriteLine();
        }

        private class Filme: IComparable
        {
            public Filme(string titulo, int ano)
            {
                Titulo = titulo;
                Ano = ano;
            }

            public string Titulo { get; }
            public int Ano { get; }

            public int CompareTo(object obj)
            {
                Filme outroFilme = obj as Filme;
                if (outroFilme == null)
                {
                    return 1;
                }

                return this.Titulo.CompareTo(outroFilme.Titulo);
            }

            public override string ToString()
            {
                return this.Titulo +  " - " + this.Ano;
            }
        }
    }


}
