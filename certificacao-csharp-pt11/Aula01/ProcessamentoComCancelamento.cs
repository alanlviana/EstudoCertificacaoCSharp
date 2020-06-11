using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_pt11.Aula01
{
    class ProcessamentoComCancelamento : IExecutavel
    {
        public void Executar()
        {
            var loopResult = Parallel.For(0, 100, (i,loopStatec) => {

                if (i == 75)
                {
                    loopStatec.Break();
                }

                Processar(i);
            });

            Console.WriteLine("Completou?"+ loopResult.IsCompleted);
            Console.WriteLine("Quantos itens foram processados?"+loopResult.LowestBreakIteration);
            
        }

        private void Processar(int i)
        {
            Console.WriteLine("Processando item: "+i);
        }
    }
}
