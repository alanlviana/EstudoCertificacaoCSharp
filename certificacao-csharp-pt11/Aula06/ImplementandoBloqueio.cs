using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace certificacao_csharp_pt11.Aula06
{
    class ImplementandoBloqueio : IExecutavel
    {
        private readonly object somaGeralLock = new object();

        long somaGeral;
        int[] items = Enumerable.Range(0, 1000001).ToArray();


        void AdicionaFaixaDeValores(int inicial, int final)
        {
            long somaParcial = 0;

            while (inicial < final)
            {
                somaParcial = somaParcial + items[inicial];
                inicial++;
            }

            //lock (somaGeralLock)
            //{
            //    somaGeral = somaGeral + somaParcial;
            //}

            Monitor.Enter(somaGeralLock);
            somaGeral = somaGeral + somaParcial;
            Monitor.Exit(somaGeralLock);

        }

        public void Executar()
        {
            while (true)
            {
                ExecutarSomaGeral();
                Thread.Sleep(1000);
            }
        }

        private void ExecutarSomaGeral()
        {
            somaGeral = 0;
            List<Task> tarefas = new List<Task>();
            int tamanhoFaixa = 1000;
            int inicioFaixa = 0;

            while (inicioFaixa < items.Length)
            {
                int fimFaixa = inicioFaixa + tamanhoFaixa;
                if (fimFaixa > items.Length) fimFaixa = items.Length;

                int i = inicioFaixa;
                int j = fimFaixa;

                tarefas.Add(Task.Run(() => AdicionaFaixaDeValores(i, j)));
                inicioFaixa = fimFaixa;
            }

            Task.WaitAll(tarefas.ToArray());

            Console.WriteLine($"A soma geral é igual a {somaGeral}");
        }
    }
}
