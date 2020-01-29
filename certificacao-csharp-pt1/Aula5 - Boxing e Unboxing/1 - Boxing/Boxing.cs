using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class Boxing : IAulaItem
    {
        public void Executar()
        {
            int numero = 57;
            object caixa = numero;

            Console.WriteLine(string.Concat("Resposta:", numero, true));

            Console.WriteLine("Class point example:");
            ClassPoint classPoint = new ClassPoint(10, 10);
            object objectClassPoint = classPoint;
            classPoint.X = 20;
            Console.WriteLine("objectClassPoint.X = " + ((ClassPoint)objectClassPoint).X); // Deve Imprimir 20

            Console.WriteLine("Struct point example:");
            StructPoint structPoint = new StructPoint(10, 10);
            object objectStructPoint = structPoint;
            structPoint.X = 20;
            Console.WriteLine("objectStructPoint.X = " + ((StructPoint)objectStructPoint).X); // Deve Imprimir 10
        }
    }

    class ClassPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public ClassPoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    struct StructPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public StructPoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}