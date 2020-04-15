using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Schema;

namespace certificacao_csharp_pt7.Aula7
{
    class AgrupamentoRelatorio : IExecutavel
    {

        public void Executar()
        {
            var filmes = GetFilmes();
            var diretores = GetDiretores();

            foreach(var filme in filmes)
            {
                Console.WriteLine($"{filme.Titulo, -40} {filme.Diretor.Nome,-20} {filme.Minutos, -4} {filme.Ano,-4}");
            }
            Console.WriteLine();

            // Quantidade por diretor
            var relatorioQuantidadePorDiretor = from filme in filmes
                                                join diretor in diretores on filme.DiretorId equals diretor.Id
                                                group filme by diretor
                                                      into agrupado
                                                select new { 
                                                    Diretor = agrupado.Key,
                                                    Quantidade = agrupado.Count(),
                                                    MinutosDirigidos = agrupado.Sum((f => f.Minutos)),
                                                    AnoPrimeiroFilme = agrupado.Min(f => f.Ano),
                                                    AnoUltimoFilme = agrupado.Max(f => f.Ano),
                                                    DuracaoMedia = agrupado.Average(f => f.Minutos),
                                                };

            Console.WriteLine("Diretores e filmes");
            foreach(var item in relatorioQuantidadePorDiretor)
            {
                Console.WriteLine($"{item.Diretor.Nome,-20}\t{item.Quantidade}\t{item.MinutosDirigidos}\t{item.AnoPrimeiroFilme}\t{item.AnoUltimoFilme}\t{item.DuracaoMedia:0.00}");
            }

            Impressao(filmes, 3, 0);
            Impressao(filmes, 3, 1);
            Impressao(filmes, 3, 2);




        }

        private void Impressao(IEnumerable<Filme> filmes, int quantidadePorPagina, int numeroPagina)
        {
            Console.WriteLine();
            Console.WriteLine($"Página {numeroPagina+1}");

            var registrosDaPagina = from filme in filmes.Skip(quantidadePorPagina * numeroPagina).Take(quantidadePorPagina)
                                    select filme;


            foreach(var filme in registrosDaPagina)
            {
                Console.WriteLine($"{filme.Titulo} - {filme.Ano}");
            }

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
