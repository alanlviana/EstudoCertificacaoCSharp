using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;

namespace certificacao_csharp_pt6.Aula6
{
    class IntroducaoConjuntos : IExecutavel
    {
        public void Executar()
        {
            var esperanca = new Filme("Episódio IV - Uma nova esperança", 1977);
            var imperio = new Filme("Episódio V - Império contra-ataca", 1980);
            var retorno = new Filme("Episódio VI - O Retorno Jedi", 1983);
            var ameaca = new Filme("Episódio I - A ameaça Fantasma", 1999);

            ISet<Filme> filmes = new HashSet<Filme>();
            filmes.Add(esperanca);
            filmes.Add(imperio);
            filmes.Add(retorno);

            ImprimirLista(filmes);

            filmes.Add(retorno);
            ImprimirLista(filmes);

            filmes.Remove(imperio);
            ImprimirLista(filmes);

            filmes.Add(ameaca);
            ImprimirLista(filmes);

            // ISet não permite acesso pelo indice
            //filmes[8]

            // A vantagem de Set é que o tempo de busca é constante conforme se aumenta o número de elementos, enquanto o crescimento de tempo de busca de List é linear
            // A desvantagem é que hashset consome mais memória.
            // A orientação é definir a estrutura com base na necessidade de acesso, se a ordem importa use List, se não, use hashset.

            // Não é possível ordenar um Set.
            List<Filme> listaFilme = new List<Filme>(filmes);
            listaFilme.Sort((f1, f2) => f1.Ano.CompareTo(f2.Ano));
            ImprimirLista(listaFilme);

            Console.WriteLine("Contem o filme esperanca?" + filmes.Contains(esperanca));
            Console.WriteLine("Contem o filme imperio?" + filmes.Contains(imperio));

            var novaEsperanca = new Filme("Episódio IV - Uma nova esperança", 1977);
            Console.WriteLine("Contem o filme nova esperanca?" + filmes.Contains(novaEsperanca));





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

            public override bool Equals(object obj)
            {
                var outro = obj as Filme;
                if (outro == null)
                {
                    return false;
                }

                return this.Titulo == outro.Titulo && this.Ano == outro.Ano;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Titulo, Ano);
            }
        }
    }


}
