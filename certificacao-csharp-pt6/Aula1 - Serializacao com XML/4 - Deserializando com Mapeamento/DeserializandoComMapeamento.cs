using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace certificacao_csharp_pt6.Aula1
{
    class DeserializandoComMapeamento : IExecutavel
    {
        private const string NOME_ARQUIVO_LOJA_FILME = "LojaFilmes.xml";

        public void Executar()
        {
            if (!File.Exists(NOME_ARQUIVO_LOJA_FILME))
            {
                Console.WriteLine("File not found.");
                return;
            }

            using (var fileStream = new FileStream(NOME_ARQUIVO_LOJA_FILME, FileMode.Open, FileAccess.Read))
            {
                var xmlSerializer = new XmlSerializer(typeof(MovieStore));
                var movieStore = (MovieStore)xmlSerializer.Deserialize(fileStream);

                foreach(var movie in movieStore.Movies)
                {
                    Console.WriteLine($"Title: {movie.Title}, Diretor Name: {movie.Director.Name}");
                }
                foreach (var director in movieStore.Directors)
                {
                    Console.WriteLine($"Name: {director.Name}, Diretor Number of Movies: {director.NumberOfMovies}");
                }
            }
        }
    }
}
