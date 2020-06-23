using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt12.Aula01
{
    public class Filme
    {
        public Filme(string diretor, string titulo, int duracaoMinutos)
        {
            Diretor = diretor;
            Titulo = titulo;
            DuracaoMinutos = duracaoMinutos;
        }

        public Filme()
        {

        }

        public string Diretor { get; set; }
        public string Titulo { get; set; }
        public int DuracaoMinutos { get; set; }

        public override string ToString()
        {
            return $"Diretor: {Diretor} Titulo: {Titulo} Duração: {DuracaoMinutos}";
        }
    }
}
