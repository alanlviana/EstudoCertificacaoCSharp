using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace certificacao_csharp_pt11.Aula03
{
    class GerenciandoTarefas : IExecutavel
    {
        public void Executar()
        {
            var task = new Task(() => ExecutaTrabalho(1));
            task.Start();
            task.Wait();

            var task2 = Task.Run(() => ExecutaTrabalho(2));
            task2.Wait();

            var task3 = Task.Run<int>(() => CalcularResultado(1, 2));
            var resultado = task3.Result;
            Console.WriteLine("O resultado do calculo é: "+ resultado);
            Console.WriteLine("Termino do processamento");
        }


        public static void ExecutaTrabalho(object item)
        {
            Console.WriteLine("Iniciando trabalho {0}", item);
            Thread.Sleep(2000);
            Console.WriteLine("Finalizando trabalho {0}", item);
            Console.WriteLine();
        }

        public static int CalcularResultado(int numero1, int numero2)
        {
            Console.WriteLine("Iniciando trabalho");
            Thread.Sleep(2000);
            Console.WriteLine("Finalizando trabalho");
            Console.WriteLine();

            return numero1 + numero2;
        }
    }
}
