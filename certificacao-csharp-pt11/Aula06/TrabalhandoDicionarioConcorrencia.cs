using ConsoleTables;
using Curso.Arquitetura.Menu;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace certificacao_csharp_pt11.Aula06
{
    class TrabalhandoDicionarioConcorrencia : IExecutavel
    {

        const int NUMERO_ITENS = 30;

        public void Executar()
        {
            ConcurrentDictionary<int, int> dicionario = new ConcurrentDictionary<int, int>();

            for (var i=0; i< NUMERO_ITENS; i++)
            {
                dicionario[i] = 0;
            }

            ImprimirDicionario(dicionario);

            Thread thread1 = new Thread(() =>
            {
                for (var i = 0; i < NUMERO_ITENS; i++)
                {
                    int valor;

                    do
                    {
                        valor = dicionario[i];
                    } while(!dicionario.TryUpdate(i, valor + 1, valor));
                    Thread.Sleep(i);
                }
            });
            thread1.Start();
            Thread thread2 = new Thread(() =>
            {
                for (var i = 0; i < NUMERO_ITENS; i++)
                {
                    int valor;

                    do
                    {
                        valor = dicionario[i];
                    } while (!dicionario.TryUpdate(i, valor + 1, valor));
                    Thread.Sleep(i);
                }
            });
            thread2.Start();

            thread1.Join();
            thread2.Join();

            ImprimirDicionario(dicionario);


        }

        private void ImprimirDicionario(IDictionary<int, int> dicionario)
        {
            ConsoleTable table = new ConsoleTable("#", "Valor");
            foreach(var keyvalue in dicionario)
            {
                table.AddRow(keyvalue.Key, keyvalue.Value);
            }
            table.Write();
        }
    }
}
