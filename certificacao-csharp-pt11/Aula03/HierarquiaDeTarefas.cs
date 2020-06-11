using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace certificacao_csharp_pt11.Aula03
{
    class HierarquiaDeTarefas : IExecutavel
    {
        public void Executar()
        {
            Task taskMae = Task.Factory.StartNew(() => {
                Console.WriteLine("Tarefa mãe iniciada!");
                for(int i = 0; i < 10; i++)
                {
                    var indiceFilha = i;
                    var tarefaFilha = Task.Factory.StartNew((id) => ExecutarFilha((int)id), indiceFilha, TaskCreationOptions.AttachedToParent);
                };
            });

            taskMae.Wait();
            Console.WriteLine("Tarefa mãe finalizada");

            Console.WriteLine();
        }

        private void ExecutarFilha(int i)
        {
            Console.WriteLine("\tTarefa filha {0} começou!", i);
            Thread.Sleep(1000);
            Console.WriteLine("\tTarefa filha {0} finalizou!", i);
        }
    }
}
