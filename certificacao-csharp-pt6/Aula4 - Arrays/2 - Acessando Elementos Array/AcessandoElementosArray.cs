using Curso.Arquitetura.Menu;
using System;

namespace certificacao_csharp_pt6.Aula4
{
    class AcessandoElementosArray : IExecutavel
    {
        public void Executar()
        {
            string alura = "Alura";
            string caelum = "Caelum";
            string casadocodigo = "Casa do Código";

            string[] empresas = { alura, caelum, casadocodigo };

            Imprimir(empresas);

            empresas[1] = "Caelum - Ensino e Inovação";

            Imprimir(empresas);

        }

        private static void Imprimir(string[] empresas)
        {
            for (int i = 0; i < empresas.Length; i++)
            {
                Console.WriteLine(empresas[i]);
            }
            Console.WriteLine();
        }
    }
}
