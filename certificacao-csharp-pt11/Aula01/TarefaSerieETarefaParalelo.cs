using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace certificacao_csharp_pt11.Aula01
{
    class TarefaSerieETarefaParalelo : IExecutavel
    {
        public void Executar()
        {

            // Em série
            Stopwatch stopwatch = Stopwatch.StartNew();
            CozinharMacarrao();
            RefogarMolho();
            stopwatch.Stop();

            Console.WriteLine("Tempo gasto cozinhando em série:" + stopwatch.ElapsedMilliseconds);

            // Em paralelo
            stopwatch.Restart();
            Parallel.Invoke(() => CozinharMacarrao(), () => RefogarMolho());
            stopwatch.Stop();
            Console.WriteLine("Tempo gasto cozinhando em paralelo:" + stopwatch.ElapsedMilliseconds);


            Console.WriteLine("Retire do fogo e ponha o molho sobre o macarrão! "+
                "Bom apetite!");
        }

        private void CozinharMacarrao()
        {
            Console.WriteLine("Cozinhando macarrão...");
            Thread.Sleep(1000);
            Console.WriteLine("Macarrão já está cozido!");
            Console.WriteLine();
        }

        private void RefogarMolho()
        {
            Console.WriteLine("Refogando molho...");
            Thread.Sleep(2000);
            Console.WriteLine("Molho já está refogado!");
            Console.WriteLine();
        }
    }
}
