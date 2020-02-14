using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt4.Item4
{
    class For : IExecutavel
    {
        public void Executar()
        {

            Console.WriteLine($"O fatorial de 5 é {CalcularFatorial(5)}");
            Console.WriteLine($"O fatorial de 4 é {CalcularFatorial(4)}");
            Console.WriteLine($"O fatorial de 3 é {CalcularFatorial(3)}");
            Console.WriteLine($"O fatorial de 2 é {CalcularFatorial(2)}");
            Console.WriteLine($"O fatorial de 1 é {CalcularFatorial(1)}");
            Console.WriteLine($"O fatorial de 0 é {CalcularFatorial(0)}");
        }

        private int CalcularFatorial(int numero)
        {
            var fatorial = 1;

            for (var i = numero; i > 0; i--)
            {
                fatorial *= i;
            }

            return fatorial;
        }

    }
}