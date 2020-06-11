using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace certificacao_csharp_pt11.Aula01
{
    class MuitosItensEmParalelo : IExecutavel
    {
        public void Executar()
        {
            var stopwatch = Stopwatch.StartNew();
            for(int i=0; i < 100; i++)
            {
                Processar(i);
            }
            stopwatch.Stop();
            Console.WriteLine("Tempo gasto com processamento em série: "+ stopwatch.ElapsedMilliseconds);

            Console.WriteLine();
            
            stopwatch.Restart();
            Parallel.For(0, 100, (i) => Processar(i));
            stopwatch.Stop();
            Console.WriteLine("Tempo gasto com processamento em paralelo: " + stopwatch.ElapsedMilliseconds);

            var numeros = System.Linq.Enumerable.Range(0, 100);
            var nomes = numeros.Select(n => "Nome "+n);
            Parallel.ForEach(nomes, (nome) => Processar(nome));

        }

        private void Processar(object item)
        {
            Console.WriteLine("Começando a trabalhar com item: "+ item);
            Thread.Sleep(100);
            Console.WriteLine("Terminando de trabalhar com item: "+ item);
        }
    }
}
