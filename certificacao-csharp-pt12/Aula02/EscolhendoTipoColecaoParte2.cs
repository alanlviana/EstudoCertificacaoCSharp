using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace certificacao_csharp_pt12.Aula02
{
    class EscolhendoTipoColecaoParte2 : IExecutavel
    {
        public void Executar()
        {
            // Matrix
            byte[,] imagem = new byte[31,14];


            // Associação entre nós
            Console.WriteLine("Ligação entre nós");
            LinkedList<string> semana = new LinkedList<string>();
            var d4 = semana.AddFirst("quarta");
            var d2 = semana.AddBefore(d4, "segunda");
            var d3 = semana.AddAfter(d2, "terça");
            var d6 = semana.AddAfter(d4, "sexta");
            var d7 = semana.AddAfter(d6, "sábado");
            var d5 = semana.AddBefore(d6, "quinta");
            var d1 = semana.AddBefore(d2, "domingo");

            foreach(var dia in semana)
            {
                Console.WriteLine(dia);
            }

            Console.WriteLine();
            Console.WriteLine("Conjuntos");

            var pares = new List<int>() { 0, 2, 4, 6, 8, 10 };
            var impares = new List<int>() { 1, 3, 5, 7, 9 };
            var primos = new List<int>() { 1, 2, 3, 5, 7 };

            var numeroAte10 = new HashSet<int>();
            pares.ForEach((i) => numeroAte10.Add(i));
            impares.ForEach((i) => numeroAte10.Add(i));
            primos.ForEach((i) => numeroAte10.Add(i));

            foreach(var i in numeroAte10)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();
            Console.WriteLine("Chaves e Valores");
            IDictionary<String, String> weekdays = new Dictionary<string, string>()
            {
                {"SEG", "MONDAY" },
                {"TER", "TUESDAY" },
                {"QUA", "WEDNESDAY" },
                {"QUI", "THURSDAY" },
                {"SEX", "FRIDAY" },
            };
            weekdays.Add("SAB", "SATURDAY");
            weekdays.Add("DOM", "SUNDAY");

            foreach(var chaveValor in weekdays)
            {
                Console.WriteLine($"{chaveValor.Key} = {chaveValor.Value}");
            }

        }
    }
}
