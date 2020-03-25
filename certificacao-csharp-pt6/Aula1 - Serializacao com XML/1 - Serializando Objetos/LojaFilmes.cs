using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace certificacao_csharp_pt6.Aula1
{
    [Serializable]
    [DataContract]
    public class LojaFilmes
    {
        [DataMember]
        public List<Diretor> Diretores = new List<Diretor>();
        [DataMember]
        public List<Filme> Filmes = new List<Filme>();

        public void AdicionaFilme(Filme filme)
        {

        }

        public static LojaFilmes ObterLojaFilmes()
        {
            var frankDarabont = new Diretor("Frank Darabont", 1);
            var francisFordCoppola = new Diretor("Francis Ford Coppola", 1);
            var christopherNolan = new Diretor("Christopher Nolan", 1);

            var filmes = new List<Filme>() {
                new Filme(frankDarabont, "Um sonho de Liberdade", "1994"),
                new Filme(francisFordCoppola, "O poderoso chefão", "1972"),
                new Filme(christopherNolan, "Batman: O Cavaleiro das Trevas", "2008")
            };

            var diretores = new List<Diretor> {
                frankDarabont,
                francisFordCoppola,
                christopherNolan
            };

            var novaLoja = new LojaFilmes();
            novaLoja.Filmes = filmes;
            novaLoja.Diretores = diretores;

            return novaLoja;
        }
    }
    [DataContract]
    [Serializable]
    public class Filme
    {
        public Filme() { }
        public Filme(Diretor diretor, string titulo, string ano)
        {
            this.Diretor = diretor;
            this.Titulo = titulo;
            this.Ano = ano;
        }
        [DataMember]
        public Diretor Diretor { get; set; }
        [DataMember]
        public string Titulo { get; set; }
        [DataMember]
        public string Ano { get; set; }
    }
    [DataContract]
    [Serializable]
    public class Diretor
    {

        public Diretor() { }
        public Diretor(string nome, int numeroFilmes)
        {
            Nome = nome;
            NumeroFilmes = numeroFilmes;
        }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public int NumeroFilmes { get; set; }
    }
}
