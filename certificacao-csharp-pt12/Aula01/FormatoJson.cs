using Curso.Arquitetura.Menu;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt12.Aula01
{
    class FormatoJson : IExecutavel
    {
        public void Executar()
        {
            Filme filme = new Filme(diretor: "James Cameron", titulo: "Titanic", duracaoMinutos: 194);

            string json = JsonConvert.SerializeObject(filme);
            Console.WriteLine("Objeto Json: "+json);

            Filme filmeConvertido = JsonConvert.DeserializeObject<Filme>(json);
            Console.WriteLine("Objeto convertido:" + filmeConvertido);

            var coletaneaJamesCameron = new List<Filme>();
            Filme filme1 = new Filme(diretor: "James Cameron", titulo: "Titanic", duracaoMinutos: 194);
            Filme filme2 = new Filme(diretor: "James Cameron", titulo: "Avatar", duracaoMinutos: 162);
            Filme filme3 = new Filme(diretor: "James Cameron", titulo: "O Exterminador do Futuro", duracaoMinutos: 104);
            coletaneaJamesCameron.Add(filme1);
            coletaneaJamesCameron.Add(filme2);
            coletaneaJamesCameron.Add(filme3);

            var jsonArrayFilmes = JsonConvert.SerializeObject(coletaneaJamesCameron);
            Console.WriteLine("Lista de filmes em JSON:"+jsonArrayFilmes);


            var listaFilmesConvertida = JsonConvert.DeserializeObject<List<FilmeSimples>>(jsonArrayFilmes);
            foreach(var item in listaFilmesConvertida)
            {
                Console.WriteLine(item);
            }


        }
    }

    class FilmeSimples
    {
        public string Diretor { get; set; }
        public string Titulo { get; set; }

        public override string ToString()
        {
            return $"Titulo: {Titulo} Diretor {Diretor}";
        }
    }
}
