using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt5.aula2
{
    class Finalizador : IExecutavel
    {
        public void Executar()
        {

            for (int i = 0; i < 1_000; i++)
            {
                Livro livro = new Livro();
            }

            GC.Collect();

        }


    }

    class Livro
    {
        private static int UltimoID = 0;
        public int Id { get;  }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public string Conclusao { get; set; }

        public Livro()
        {
            UltimoID++;
            Id = UltimoID;
            Console.WriteLine($"O livro de id:{Id} está sendo criado.");
        }

        ~Livro() {
            // Liberar recursos não gerenciados
            Console.WriteLine($"O livro de id:{Id} está sendo destruido.");
        }
    }
}
