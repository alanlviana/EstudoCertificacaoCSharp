using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class PontoFlutuante : IAulaItem
    {
        public void Executar()
        {

            float idade = 15;
            idade = 15.5f;

            //int massa = 6_00000_00000_00000_00000_0000;
            //long massa = 6e24;

            Console.WriteLine($"long.MaxValue = {long.MaxValue}");
            Console.WriteLine($"long.MinValue = {long.MinValue}");
            Console.WriteLine($"float.MinValue = {float.MinValue}");
            Console.WriteLine($"float.MinValue = {float.MinValue}");

            float massaTerra = 5.9736e24f; // System.Single
            Console.WriteLine($"Massa da Terra {massaTerra}");

            float numeroPi = 3.14159f;
            Console.WriteLine($"Número PI = {numeroPi}");

            double numeroMuitoMaior = 6e100d; // System.Double
            Console.WriteLine($"Número muito maior {numeroMuitoMaior}");

            Console.WriteLine();
            int x = 3;
            short y = 5;
            var resultado = x * y;
            Console.WriteLine($"x * y = {resultado}");
            Console.WriteLine($"x * y (Tipo de Resultado) = {resultado.GetType()}");

            float z = 4.5f;
            var resultado2 = (x * y) / z;
            Console.WriteLine($"(x * y) / z = {resultado2}");
            Console.WriteLine($"(x * y) / z (Tipo de Resultado) = {resultado2.GetType()}");

        }
    }
}
