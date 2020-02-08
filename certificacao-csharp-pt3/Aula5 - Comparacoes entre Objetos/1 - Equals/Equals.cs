using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt3.Aula5
{
    class Equals : IExecutavel
    {
        public void Executar()
        {
            var aluno1 = new Aluno()
            {
                Nome = "José da Silva",
                DataNascimento = new DateTime(1993, 12, 15)
            };
            var aluno2 = new Aluno()
            {
                Nome = "José da Silva",
                DataNascimento = new DateTime(1996, 12, 15)
            };
            var aluno3 = new Aluno()
            {
                Nome = "josé da silva",
                DataNascimento = new DateTime(1993, 12, 15)

            };
            var aluno4 = new Aluno()
            {
                Nome = "andre dos santos",
                DataNascimento = new DateTime(1983, 12, 15)

            };

            var aluno5 = new Aluno()
            {
                Nome = "ana de souza",
                DataNascimento = new DateTime(1990, 01, 01)
            };

            List<Aluno> alunos = new List<Aluno>()
            {
                aluno1,
                aluno2,
                aluno3,
                aluno4,
                aluno5
            };

            alunos.Sort();

            foreach(var aluno in alunos)
            {
                Console.WriteLine(aluno);
            }

            Console.WriteLine($"aluno1.Equals(aluno2): {aluno1.Equals(aluno2)}");
            Console.WriteLine($"aluno1.Equals(aluno3): {aluno1.Equals(aluno3)}");

        }
    }

    class Aluno: IComparable
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public override string ToString()
        {
            return $"Nome: {Nome}, Data de Nascimento: {DataNascimento:dd/MM/yyyy}";
        }

        public override bool Equals(object obj)
        {
            var outro = obj as Aluno;

            if (outro == null)
            {
                return false;
            }

            return this.Nome.Equals(outro.Nome, StringComparison.CurrentCultureIgnoreCase) 
                && this.DataNascimento.Equals(outro.DataNascimento);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Nome, DataNascimento);
        }

        public int CompareTo(object obj)
        {
            var outro = obj as Aluno;

            if (outro == null)
            {
                throw new ArgumentException("obj não é Aluno.");
            }

            var resultado = outro.DataNascimento.CompareTo(DataNascimento);

            if (resultado == 0)
            {
                resultado = outro.Nome.CompareTo(Nome);
            }

            return resultado;
        }
    }
}
