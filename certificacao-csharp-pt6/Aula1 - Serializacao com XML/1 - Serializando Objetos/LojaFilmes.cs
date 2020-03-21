using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt6.Aula1
{
    public class LojaFilmes
    {
        public List<Diretor> Diretores = new List<Diretor>();
        public List<Filme> Filmes = new List<Filme>();

        public void AdicionaFilme(Filme filme)
        {

        }
    }

    public class Filme
    {
        public Filme() { }
        public Filme(Diretor diretor, string titulo, string ano)
        {
            this.Diretor = diretor;
            this.Titulo = titulo;
            this.Ano = ano;
        }

        public Diretor Diretor { get; set; }
        public string Titulo { get; set; }
        public string Ano { get; set; }
    }

    public class Diretor
    {

        public Diretor() { }
        public Diretor(string nome, int numeroFilmes)
        {
            Nome = nome;
            NumeroFilmes = numeroFilmes;
        }

        public string Nome { get; set; }
        public int NumeroFilmes { get; set; }
    }
}
