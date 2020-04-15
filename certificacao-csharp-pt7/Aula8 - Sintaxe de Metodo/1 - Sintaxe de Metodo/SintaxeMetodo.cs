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
    class SintaxeMetodo : IExecutavel
    {

        public void Executar()
        {
            var filmes = GetFilmes();
            var diretores = GetDiretores();


            var query = filmes.Join(diretores,
                f => f.DiretorId,
                d => d.Id,
                (f, d) => new { Titulo = f.Titulo, DiretorId = d.Id }
            );

            foreach(var item in query)
            {
                Console.WriteLine(item.Titulo +" - "+item.DiretorId);
            }



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

        public class Diretor
        {
            public int Id{ get; set; }
            public string Nome { get; set; }
        }

        public class Filme
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
