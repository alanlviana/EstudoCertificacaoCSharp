using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class Booleanos : IExecutavel
    {
        public void Executar()
        {
            //bool possuiSaldo = 1; // Erro
            bool possuiSaldo = true;

            Console.WriteLine($"possuiSaldo: {possuiSaldo}");

            int dias = DateTime.Now.Day;
            Console.WriteLine($"Dia: {dias}");
            bool diasPar = dias % 2 == 0;
            if (diasPar == true)
            {
                Console.WriteLine("Hoje é um dia par");
            }
            else
            {
                Console.WriteLine("Hoje é um dia ímpar");
            }

        }
    }
}
