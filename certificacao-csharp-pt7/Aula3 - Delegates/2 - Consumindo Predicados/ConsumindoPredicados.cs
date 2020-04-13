using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace certificacao_csharp_pt7.Aula3
{
    class ConsumindoPredicados : IExecutavel
    {
        delegate int OperacaoMatematica(int x, int y);

        public void Executar()
        {
            var numeros = new int[]{ 1,2,3,4,5,6,7,8,9};
            Predicate<int> divisivelPor3 = (i) => i % 3 == 0;

            var numerosDivisiveisPor3 = Array.FindAll(numeros, divisivelPor3);
                
            foreach(var numero in numerosDivisiveisPor3)
            {
                Console.WriteLine($"Número {numero} é divisível por 3.");
            }

        }

    }
}
