using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt12.Aula02
{
    class EscolhendoTipoColecaoParte1 : IExecutavel
    {
        public void Executar()
        {
            // FIFO
            Console.WriteLine("FIFO");
            Queue<string> fila = new Queue<string>();
            fila.Enqueue("Van");
            fila.Enqueue("Kombi");
            fila.Enqueue("Guincho");
            fila.Enqueue("Pickup");

            Console.WriteLine("Saindo da fila:");
            while (fila.TryDequeue(out string veiculo))
            {
                Console.WriteLine(veiculo);
            }
            Console.WriteLine();

            //LIFO
            Console.WriteLine("LIFO");
            Stack<string> pilha = new Stack<string>();
            pilha.Push("<<vazio>>");
            pilha.Push("google.com.br");
            pilha.Push("caelum.com.br");
            pilha.Push("alura.com.br");

            Console.WriteLine("Retirando da pilha");
            while(pilha.TryPop(out string site))
            {
                Console.WriteLine(site);
            }

            // Coleção mais poderosa
            Console.WriteLine();
            Console.WriteLine("Coleção mais versátil");
            List<String> meses = new List<string>()
            {
                "janeiro", "fevereiro", "marco", "abril", "abril", "maio", "junho", "julho", "agosto"
            };

            meses.Add("setembro");
            meses.AddRange(new string[] { "novembro", "dezembro", "onzembro" });

            meses.RemoveAt(4);
            meses.RemoveAt(meses.Count - 1);
            meses.Insert(9, "outubro");

            for(int i=0; i< meses.Count; i++)
            {
                Console.WriteLine(meses[i]);
            }
            Console.WriteLine();
            meses.Sort((m1, m2) => m1.CompareTo(m2));
            for (int i = 0; i < meses.Count; i++)
            {
                Console.WriteLine(meses[i]);
            }
        }
    }
}
