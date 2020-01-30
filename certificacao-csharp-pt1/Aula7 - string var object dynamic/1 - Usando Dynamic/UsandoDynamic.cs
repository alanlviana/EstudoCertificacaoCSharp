using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class UsandoDynamic : IAulaItem
    {
        public void Executar()
        {
            // tipo definido na compilação
            string s = "certificacao c#";
            // tipo string definido na compilação, o tipo é definido por inferência, com baso no tipo atribuido
            var v = "certificacao c#";
            // tipo object definido na compilação, pode armazenar qualquer outro tipo
            object o = "certificacão c#";

            Console.WriteLine(s);
            Console.WriteLine(v);
            Console.WriteLine(o);

            s = s.ToUpper();
            v = v.ToUpper();
            o = ((string)o).ToUpper();

            Console.WriteLine(s);
            Console.WriteLine(v);
            Console.WriteLine(o);

            //s = 123; // Cannot implicitly convert type 'int' to 'string'
            //v = 123; // Cannot implicitly convert type 'int' to 'string'
            o = 123;
            o = (int)o + 4;

            Console.WriteLine(o);

            dynamic d = "certificacao c#";
            Console.WriteLine(d);
            d = d.ToUpper();
            Console.WriteLine(d);

            d = 123;
            Console.WriteLine(d);

            d = d + 4;
            Console.WriteLine(d);


        }
    }

}