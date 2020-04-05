using Curso.Arquitetura.Menu;
using System;

namespace certificacao_csharp_pt6.Aula4
{
    class OrdenandoCopiandoClonandoLimpandoArray : IExecutavel
    {
        public void Executar()
        {
            string alura = "Alura";
            string caelum = "Caelum";
            string casadocodigo = "Casa do Código";

            string[] empresas = { alura, caelum, casadocodigo };

            Console.WriteLine("O primeiro elemento do array é:" + empresas[0]);
            Console.WriteLine("O último elemento do array é:" + empresas[empresas.Length-1]);

            Console.WriteLine("O índice do primeiro elemento 'Casa do Código é:'"+ Array.IndexOf(empresas, casadocodigo));
            Console.WriteLine("O índice do último elemento 'Casa do Código é:'" + Array.LastIndexOf(empresas, casadocodigo));
            Console.WriteLine("O índice do p´roximo elemento 'Casa do Código é:'" + Array.IndexOf(empresas, casadocodigo, 0));

            Array.Sort(empresas);
            ImprimirArray(empresas);

            string[] copia = new string[2];
            Array.Copy(empresas, 1, copia, 0, 2);

            Console.WriteLine("Imprimindo cópia");
            ImprimirArray(copia);

            string[] clone = empresas.Clone() as string[];
            Console.WriteLine("Imprimir clone");
            ImprimirArray(clone);

            Array.Clear(empresas, 1, 2);
            Console.WriteLine("Imprimindo array após limpeza");
            ImprimirArray(empresas);


        }

        private void ImprimirArray(string[] empresas)
        {
            for (int i = 0; i < empresas.Length; i++)
            {
                Console.WriteLine(i +" - "+ empresas[i]);
            }
            Console.WriteLine();
        }
    }
}
