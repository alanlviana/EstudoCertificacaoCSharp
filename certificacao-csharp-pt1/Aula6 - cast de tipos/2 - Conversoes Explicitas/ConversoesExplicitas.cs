using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class ConversoesExplicitas : IExecutavel
    {
        public void Executar()
        {
            double divida = 1_234_567_890.123;
            //long copia = divida; // Cannot implicitly convert 'double' to 'long'. An Explicit conversion exists (are you missing a cast?)

            double salario = 1_237.89;
            //long copiaSalario = salario; // Cannot implicitly convert 'double' to 'long'. An Explicit conversion exists (are you missing a cast?)
            long copiaSalario = (long)salario;
            Console.WriteLine("Salario (long):"+copiaSalario); // 1237

            Animal animal = new Gato();
            Gato gato = (Gato)animal;
            Console.WriteLine("gato.getType(): "+ gato.GetType());


        }
    }

}