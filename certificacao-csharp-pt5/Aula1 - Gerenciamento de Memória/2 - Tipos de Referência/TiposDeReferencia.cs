using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_pt5
{
    class TiposDeReferencia: IExecutavel
    {
        public async void Executar()
        {
            await Task.Delay(3000);

            //ProcessarEstruturaLivro();
            ProcessarClasseLivro();

            Console.ReadLine();

        }

        private void ProcessarEstruturaLivro()
        {
            for (int i = 0; i < 100_000; i++)
            {
                var livro = new EstruturaLivro()
                {
                    NumeroDePaginas = i
                };
            }
        }

        private void ProcessarClasseLivro()
        {
            for (int i = 0; i < 100_000; i++)
            {
                var livro = new ClasseLivro()
                {
                    Introducao = new string('0', 10_000),
                    Texto = new string('0', 10_000),
                    Conclusao = new string('0', 10_000),
                };
            }
        }
    }

    struct EstruturaLivro
    {
        public double NumeroDePaginas { get;set; }
    }

    class ClasseLivro
    {
        public string Introducao { get; set; }
        public string Texto { get; set; }
        public string Conclusao { get; set; }
    }
}
