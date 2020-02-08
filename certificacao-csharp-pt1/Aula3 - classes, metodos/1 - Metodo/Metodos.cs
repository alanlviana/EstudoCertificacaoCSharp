using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class Metodos : IExecutavel
    {
        public void Executar()
        {
            Retangulo retangulo = new Retangulo(12, 10);
            Console.WriteLine($"retangulo.GetArea(): {retangulo.GetArea()}");

            Retangulo outroRetangulo = new Retangulo(10, 10);
            Console.WriteLine($"retangulo.Semelhante(outroRetangulo): {Retangulo.Semelhante(retangulo, outroRetangulo)}");

            Retangulo retanguloQuadrado = new Retangulo(29, 29);
            Console.WriteLine($"outroRetangulo.Semelhante(retanguloQuadrado): {Retangulo.Semelhante(outroRetangulo,retanguloQuadrado)}");


        }
    }

    class Retangulo
    {
        public Retangulo(double altura, double largura)
        {
            Altura = altura;
            Largura = largura;

            Console.WriteLine($"Altura: {Altura}, Largura: {Largura}");
        }

        internal double GetArea()
        {
            return Altura * Largura;
        }

        internal static bool Semelhante(Retangulo retangulo, Retangulo outroRetangulo)
        {
            var proporcao = retangulo.Altura / retangulo.Largura;
            var proporcaoOutroRetangulo = outroRetangulo.Altura / outroRetangulo.Largura;
            return proporcao == proporcaoOutroRetangulo;
        }

        public double Altura { get; set; }
        public double Largura { get; set; }
    }

}
