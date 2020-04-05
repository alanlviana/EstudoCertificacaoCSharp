using Curso.Arquitetura.Menu;
using System;

namespace certificacao_csharp_pt6.Aula4
{
    class IntroducaoArrays : IExecutavel
    {
        public void Executar()
        {
            string alura = "Alura";
            string caelum = "Caelum";
            string casadocodigo = "Casa do Código";

            string[] empresas = { alura, caelum, casadocodigo };

            Console.WriteLine(empresas[0]);
            Console.WriteLine(empresas[1]);
            Console.WriteLine(empresas[2]);
        }
    }
}
