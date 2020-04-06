using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;

namespace certificacao_csharp_pt6.Aula6
{
    class IntroducaoDicionarios : IExecutavel
    {
        public void Executar()
        {
            var esperanca = new Filme("Episódio IV - Uma nova esperança", 1977);
            var imperio = new Filme("Episódio V - Império contra-ataca", 1980);
            var retorno = new Filme("Episódio VI - O Retorno Jedi", 1983);
            var ameaca = new Filme("Episódio I - A ameaça Fantasma", 1999);

            var filmes  = new Dictionary<int, Filme>();
            filmes.Add(34672, esperanca);
            filmes.Add(5617, imperio);
            filmes.Add(17645, retorno);

            foreach(var filme in filmes)
            {
                Console.WriteLine(filme);
                Console.WriteLine(filme.Key);
                Console.WriteLine(filme.Value);
            }

            var filme34672 = filmes[34672];
            Console.WriteLine("O indice de 34672 é:" + filme34672.Titulo);

            filmes[34672] = ameaca;
            Console.WriteLine("O indice de 34672 é:" + filmes[34672].Titulo);

            //Console.WriteLine("Buscando um valor que não existe!" + filmes[123]);  // System.Collections.Generic.KeyNotFoundException:

            Console.WriteLine("Verificando se 34673 existe:" + filmes.ContainsKey(34673));


            if (filmes.TryGetValue(123,out Filme meufilme))
            {
                Console.WriteLine("Filme 123 encontrado!");
            }
            else
            {
                Console.WriteLine("Filme 123 não encontrado!");
            }

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
