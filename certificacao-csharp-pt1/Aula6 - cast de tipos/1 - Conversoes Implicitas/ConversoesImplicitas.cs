using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class ConversoesImplicitas : IAulaItem
    {
        public void Executar()
        {
            int inteiro = 2_123_456_789;
            long inteiroLongo = inteiro;

            Console.WriteLine("Inteiro Longo= "+ inteiroLongo);
            //inteiro = inteiroLongo; //Cannot implicitly convert type 'long' to 'int'. An explicit conversion exists (are you missing a cast?)

            Gato gato = new Gato();
            Animal animal = gato;
            Console.WriteLine("animal.GetType() = "+animal.GetType());

            IAnimal ianimal = gato;
            Console.WriteLine("ianimal.GetType() = " + ianimal.GetType());

            //gato = animal;// Cannot implicitly convert type 'Animal' to 'Gato'. An explicit conversion exists (are you missing a cast?)

        }
    }

    // De - Para
    // sbyte = short, int , long float, double ou decimal
    // byte = shourt , ushort, int, uint, long, float, double ou decimal
    // short = int, long, float, double ou decimal
    // ushort = int, uint, long, ulong, float, double ou decimal
    // int = long, float, double ou decimal
    // uint = long, ulong, float, double ou decimal
    // long = float, double ou decimal
    // chat = ushort, int, uint, long, ulong, float, double ou decimal
    // float = double
    // ulong = float, double ou decimal
    // double = (nenhum)
    // decimal = (nenhum)
}