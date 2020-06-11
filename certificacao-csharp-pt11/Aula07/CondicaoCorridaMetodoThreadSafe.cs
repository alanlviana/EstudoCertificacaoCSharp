using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace certificacao_csharp_pt11.Aula07
{
    class CondicaoCorridaMetodoThreadSafe : IExecutavel
    {
        public void Executar()
        {
            Contador contador = new Contador();
            Thread thread1 = new Thread(() =>
            {
                for(int i=0; i < 50; i++)
                {
                    contador.Incrementar();
                    Thread.Sleep(i);
                }
            });
            Thread thread2 = new Thread(() =>
            {
                for (int i = 0; i < 50; i++)
                {
                    contador.Incrementar();
                    Thread.Sleep(i);

                }
            });

            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();

            Console.WriteLine("O valor do contador é {0}", contador.Numero);



        }
    }

    class Contador
    {
        static private object _numeroLock = new object();
        public int Numero { get; private set; }

        public void Incrementar()
        {
            lock (_numeroLock)
            {
                Numero++;
            }
        }
    }
}
