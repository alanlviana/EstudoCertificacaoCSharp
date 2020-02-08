using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    public class Strings : IExecutavel
    {
        public void Executar()
        {
            string a = "bom dia";
            string b = "b";

            b = b + "om dia";

            Console.WriteLine($" a == b: {a == b}");
            Console.WriteLine($"(object)a == (object)b: {(object)a == (object)b}");
            
            string bomDia = "bom dia";
            char d = bomDia[4];
            Console.WriteLine($"bomdia[4]: {bomDia[4]}");
            Console.WriteLine($"d.GetType(): {d.GetType()}");
        }
    }

}

