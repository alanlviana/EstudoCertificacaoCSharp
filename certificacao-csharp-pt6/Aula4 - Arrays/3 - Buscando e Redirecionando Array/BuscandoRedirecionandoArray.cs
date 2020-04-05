﻿using Curso.Arquitetura.Menu;
using System;

namespace certificacao_csharp_pt6.Aula4
{
    class BuscandoRedirecionandoArray : IExecutavel
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

            // Invertendo array
            Array.Reverse(empresas);
            ImprimirArray(empresas);

            // Dfazendo reverter array
            Array.Reverse(empresas);
            ImprimirArray(empresas);

            // Redimencionando
            Array.Resize(ref empresas, 2);
            ImprimirArray(empresas);

            // Redimencionando
            Array.Resize(ref empresas, 3);
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
