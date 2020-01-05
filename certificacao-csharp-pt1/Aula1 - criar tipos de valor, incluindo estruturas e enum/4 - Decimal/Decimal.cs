using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class Decimal : IAulaItem
    {
        public void Executar()
        {
            double valorProduto1 = 10;
            double valorProduto2 = 20;
            double subtotal = 30;

            Console.WriteLine("Descobrindo se 10 + 20 = 30");
            Console.WriteLine(valorProduto1 + valorProduto2 == subtotal); // True

            valorProduto1 = 10.10;
            valorProduto2 = 20.20;
            subtotal = 30.30;

            Console.WriteLine("Descobrindo se 10.10 + 20.20 = 30.30");
            Console.WriteLine(valorProduto1 + valorProduto2 == subtotal); // False
            Console.WriteLine($"valorProduto1 + valorProduto2 + {valorProduto1 + valorProduto2}");
            
            Console.WriteLine("Descobrindo se 10.10 + 20.20 = 30.299999999999997");
            Console.WriteLine(valorProduto1 + valorProduto2 == 30.299999999999997); // True

            ///// ------ DECIMAL -------

            decimal materiaPrima = 10.1m;
            decimal maoDeObra = 20.2m;
            decimal custo = 30.3m;
            
            Console.WriteLine();
            Console.WriteLine("DECIMAL");
            Console.WriteLine("Descobrindo se 10.1 + 20.2 = 30.3");
            Console.WriteLine(materiaPrima + maoDeObra == custo); // True



        }
    }
}
