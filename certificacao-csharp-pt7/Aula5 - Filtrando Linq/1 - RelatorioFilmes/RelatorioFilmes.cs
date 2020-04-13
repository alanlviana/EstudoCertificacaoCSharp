using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Schema;

namespace certificacao_csharp_pt7.Aula5
{
    class RelatorioFilmes : IExecutavel
    {

        public void Executar()
        {
            var filmes = GetFilmes();
            var diretores = GetDiretores();

            var fantasticaFabricaDeChocolate = new Filme
            {
                Titulo = "A Fantástica Fábrica de Chocolate",
                Ano = 2005,
                DiretorId = 3,
                Diretor = new Diretor
                {
                    Id = 3,
                    Nome = "Tim Burton"
                }
            };

            filmes.Add(fantasticaFabricaDeChocolate);

            var consultaTimBurton = from filme in filmes
                                    where filme.Diretor.Nome == "Tim Burton"
                                    select filme;


            var consultaNomesFilmesTimBurton = from filme in filmes
                                               where filme.Diretor.Nome == "Tim Burton"
                                               select new FilmeResumido{ TituloResumido= filme.Titulo, NomeDiretor = filme.Diretor.Nome };



            var consultaAnonimaTimBurton = from filme in filmes
                                               where filme.Diretor.Nome == "Tim Burton"
                                               select new { filme.Titulo, NomeDiretor = filme.Diretor.Nome };

            Console.WriteLine("Lista de objectos anonimos");
            Console.WriteLine(new string('#', 66));
            Console.WriteLine($"{"Titulo",-40} {"Diretor",-20}");
            Console.WriteLine(new string('#', 66));
            foreach (var filme in consultaAnonimaTimBurton)
            {
                Console.WriteLine($"{filme.Titulo,-40} {filme.NomeDiretor,-20}");
            }
            Console.WriteLine(new string('#', 66));
            Console.WriteLine();

            var consultaFilmesComDiretores = from filme in filmes
                                             join diretor in diretores on filme.DiretorId equals diretor.Id
                                             orderby diretor.Nome
                                             select new { Titulo = filme.Titulo, NomeDiretor = diretor.Nome };


            // LINQ = Consulta integrada à linguagem

            ImprimirListaDeFilmes("Lista de todos os filmes", filmes);
            ImprimirListaDeFilmes("Lista filme do Tim Burton", consultaTimBurton);
            ImprimirListaDeFilmes("Lista resumida de tim Burton", consultaNomesFilmesTimBurton);

        }

        private static void ImprimirListaDeFilmes(string titulo,IEnumerable<Filme> filmes)
        {
            Console.WriteLine(titulo);
            Console.WriteLine(new string('#', 66));
            Console.WriteLine($"{"Titulo",-40} {"Diretor",-20} {"Ano",-4}");
            Console.WriteLine(new string('#', 66));
            foreach (var filme in filmes)
            {
                Console.WriteLine($"{filme.Titulo,-40} {filme.Diretor.Nome,-20} {filme.Ano,-4}");
            }
            Console.WriteLine(new string('#', 66));
            Console.WriteLine();
        }

        private static void ImprimirListaDeFilmes(string titulo, IEnumerable<FilmeResumido> filmes)
        {
            Console.WriteLine(titulo);
            Console.WriteLine(new string('#', 66));
            Console.WriteLine($"{"Titulo",-40} {"Diretor",-20}");
            Console.WriteLine(new string('#', 66));
            foreach (var filme in filmes)
            {
                Console.WriteLine($"{filme.TituloResumido,-40} {filme.NomeDiretor,-20}");
            }
            Console.WriteLine(new string('#', 66));
            Console.WriteLine();
        }

        static List<Diretor> GetDiretores(){
            return new List<Diretor>
            {
                new Diretor(){ 
                    Id = 1,
                    Nome = "Quentin Tarantino"
                },
                new Diretor()
                {
                    Id = 2,
                    Nome = "James Cameron"
                },
                new Diretor()
                {
                    Id = 3,
                    Nome = "Tim Burtom"
                }
            };
        }

        static List<Filme> GetFilmes()
        {
            return new List<Filme>
            {
                new Filme()
                {
                    DiretorId = 1,
                    Diretor = new Diretor(){Nome = "Quentin Tarantino"},
                    Titulo = "Pulp Fiction",
                    Ano = 1994,
                    Minutos = 2*60 + 34
                },
                new Filme(){
                    DiretorId = 1,
                    Diretor = new Diretor(){Nome="Quentin Tarantino"},
                    Titulo = "Django Livre",
                    Ano = 2012,
                    Minutos = 2*60+45
                },
                new Filme()
                {
                    DiretorId = 1,
                    Diretor = new Diretor(){Nome="Quentin Tarantino"},
                    Titulo = "Kill Bill Volume 1",
                    Ano = 2003,
                    Minutos = 1*60+51
                },
                new Filme()
                {
                    DiretorId = 2,
                    Diretor = new Diretor(){Nome="James Cameron"},
                    Titulo = "Avatar",
                    Ano = 2009,
                    Minutos = 2*60+42
                },
                new Filme()
                {
                    DiretorId = 2,
                    Diretor = new Diretor(){Nome="James Cameron"},
                    Titulo = "Titanic",
                    Ano = 1997,
                    Minutos = 3*60+14
                },
                new Filme()
                {
                    DiretorId = 2,
                    Diretor = new Diretor(){Nome="James Cameron"},
                    Titulo = "O Exterminador do Futudo",
                    Ano = 1984,
                    Minutos = 1*60+47
                },
                new Filme()
                {
                    DiretorId = 3,
                    Diretor = new Diretor(){Nome="Tim Burton"},
                    Titulo = "Alice no país das maravilhas",
                    Ano = 2010,
                    Minutos = 1*60+48
                },
                new Filme()
                {
                    DiretorId = 3,
                    Diretor = new Diretor(){Nome="Tim Burton"},
                    Titulo = "A Noiva Cádaver",
                    Ano = 2005,
                    Minutos = 1*60+17
                },
            };
        }

        private class Diretor
        {
            public int Id{ get; set; }
            public string Nome { get; set; }
        }

        private class Filme
        {
            public int DiretorId { get; set; }
            public Diretor Diretor{ get; set; }
            public string Titulo{ get; set; }
            public int Ano { get; set; }
            public int Minutos { get; set; }
        }
        private class FilmeResumido
        {
            public string TituloResumido { get; set; }
            public string NomeDiretor { get; set; }
        }
    }
}
