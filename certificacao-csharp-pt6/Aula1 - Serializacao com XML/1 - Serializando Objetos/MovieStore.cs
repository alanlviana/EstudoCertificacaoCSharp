using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace certificacao_csharp_pt6.Aula1
{
    [JsonObject("LojaFilmes")]
    [XmlRoot("LojaFilmes")]
    public class MovieStore
    {
        [JsonProperty("Diretores")]
        [XmlArray("Diretores")]
        public List<Director> Directors = new List<Director>();
        [JsonProperty("Filmes")] 
        [XmlArray("Filmes")]
        public List<Movie> Movies = new List<Movie>();

        public void AddMovie(Movie movie)
        {

        }
    }

    [JsonObject("Filme")]
    [XmlType("Filme")]
    public class Movie
    {
        [JsonProperty("Diretor")]
        [XmlElement("Diretor")]
        public Director Director { get; set; }
        [JsonProperty("Titulo")]
        [XmlElement("Titulo")]
        public string Title { get; set; }
        [JsonProperty("Ano")]
        [XmlElement("Ano")]
        public string Year { get; set; }
    }

    [JsonObject("Diretor")]
    [XmlType(TypeName = "Diretor")]
    public class Director
    {
        [JsonProperty("Nome")]
        [XmlElement("Nome")]
        public string Name { get; set; }
        [JsonProperty("NumeroFilmes")]
        [XmlElement("NumeroFilmes")]
        public string NumberOfMovies { get; set; }
    }
}
