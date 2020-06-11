using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace certificacao_csharp_pt11.Auto04
{
    class UsandoOPollDeThreads : IExecutavel
    {
        public void Executar()
        {
            for(int i=0;i < 50; i++)
            {
                ThreadPool.QueueUserWorkItem((state) => Executar(state), i);
            }
        }

        private static void Executar(object state)
        {
            Console.WriteLine("Executando {0} na thread {1}", state, Thread.CurrentThread.ManagedThreadId);
        }
    }
}
