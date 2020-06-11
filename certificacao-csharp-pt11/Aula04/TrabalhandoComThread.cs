using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace certificacao_csharp_pt11.Auto04
{
    class TrabalhandoComThread : IExecutavel
    {
        public void Executar()
        {
            ExibirThread(Thread.CurrentThread);

            Thread thread = new Thread(threadStart);
            thread.Start();
            thread.Join();

            Thread thread2 = new Thread(() => Console.WriteLine("Thread 2 executada!"));
            thread2.Start();
            thread2.Join();

            ParameterizedThreadStart ps = new ParameterizedThreadStart((o) => Console.WriteLine("Iniciado com valor {0}", o));
            Thread thread3 = new Thread(ps);
            thread3.Start("Parametro!");
            thread3.Join();


            bool relogioFuncionando = true;
            Thread threadRelogio = new Thread(() => {
                while (relogioFuncionando)
                {
                    Console.WriteLine("tic");
                    Thread.Sleep(1000);
                    Console.WriteLine("tac");
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Relógio interrompido!");
                ExibirThread(Thread.CurrentThread);
            });

            threadRelogio.Start();
            Console.WriteLine("Tecle algo para interromper");
            Console.ReadKey();
            relogioFuncionando = false;
            threadRelogio.Join();

           



        }

        private void ExibirThread(Thread thread)
        {
            Console.WriteLine();
            Console.WriteLine("Id {0}", thread.ManagedThreadId);
            Console.WriteLine("Nome {0}", thread.Name);
            Console.WriteLine("Cultura {0}", thread.CurrentCulture);
            Console.WriteLine("Prioridade {0}", thread.Priority);
            Console.WriteLine("Contexto {0}", thread.ExecutionContext);
            Console.WriteLine("Está em background {0}", thread.IsBackground);
            Console.WriteLine("Está no pool de threads {0}", thread.IsThreadPoolThread);
            Console.WriteLine();
        }

        private void threadStart(object obj)
        {
            Console.WriteLine("Inicio da execução!");
            Thread.Sleep(1000);
            Console.WriteLine("Fim da execução!");
        }
    }
}
