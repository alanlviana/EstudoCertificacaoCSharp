using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace certificacao_csharp_pt6.Aula1
{

    [XmlRoot("LojaFilmes")]
    public class MovieStore
    {
        [XmlArray("Diretores")]
        public List<Director> Directors = new List<Director>();
        [XmlArray("Filmes")]
        public List<Movie> Movies = new List<Movie>();

        public void AddMovie(Movie movie)
        {

        }
    }

    [XmlType("Filme")]
    public class Movie
    {
        [XmlElement("Diretor")]
        public Director Director { get; set; }
        [XmlElement("Titulo")]
        public string Title { get; set; }
        [XmlElement("Ano")]
        public string Year { get; set; }
    }

    [XmlType(TypeName = "Diretor")]
    public class Director
    {
        [XmlElement("Nome")]
        public string Name { get; set; }
        [XmlElement("NumeroFilmes")]
        public string NumberOfMovies { get; set; }
    }
}
