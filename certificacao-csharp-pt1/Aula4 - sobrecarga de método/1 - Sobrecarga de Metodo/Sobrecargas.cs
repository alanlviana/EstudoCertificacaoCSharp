using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class Sobrecargas : IAulaItem
    {
        public void Executar()
        {
            int lado = 3;
            Console.WriteLine($"Volume do Cubo: {Volume(lado)}");

            int raio = 2;
            int altura = 10;
            Console.WriteLine($"Volume do Cilindro: {Volume(altura, raio)}");

            long largura = 10;
            altura = 6;
            int profundidade = 4;
            Console.WriteLine($"Volume do Prisma: {Volume(largura, altura, profundidade)}");




        }

        double Volume(double lado)
        {
            return Math.Pow(lado, 3);
        }

        double Volume(double altura, double raio)
        {
            return altura * Math.PI * Math.Pow(raio, 2);
        }

        double Volume(double largura, double altura, double profundidade)
        {
            return largura * altura * profundidade;
        }   
    }


}
