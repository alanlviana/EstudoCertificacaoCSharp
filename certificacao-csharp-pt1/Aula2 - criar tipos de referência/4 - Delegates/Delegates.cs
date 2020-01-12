using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    public class Delegates : IAulaItem
    {
        public void Executar()
        {
            Calculadora.Executar();
        }
    }

    delegate double MetodoMultiplicacao(double input);

    class Calculadora
    {
        static double Duplicar(double input)
        {
            return input * 2;
        }
        static double Triplicar(double input)
        {
            return input * 3;
        }

        public static void Executar()
        {
            Console.WriteLine($"Duplicar(7.5): {Duplicar(7.5)}");
            Console.WriteLine($"Triplicar(7.5): {Triplicar(7.5)}");

            Console.WriteLine("Método duplicar com delegate");
            MetodoMultiplicacao metodo = Duplicar;
            Console.WriteLine(metodo(7.5));
            
            Console.WriteLine("Método triplicar com delegate");
            metodo = Triplicar;
            Console.WriteLine(metodo(7.5));

            Console.WriteLine("Método quadrado com delegate e método anonimo");
            MetodoMultiplicacao metodoQuadrado = delegate (double input)
            {
                return input * input;
            };
            Console.WriteLine(metodoQuadrado(5));

            Console.WriteLine("Método cubo com delegate e método anonimo (lambda)");
            MetodoMultiplicacao metodoCuboLambda = (input) => {
                return input * input * input;
            };

            Console.WriteLine(metodoCuboLambda(2));
        }
    }
}
