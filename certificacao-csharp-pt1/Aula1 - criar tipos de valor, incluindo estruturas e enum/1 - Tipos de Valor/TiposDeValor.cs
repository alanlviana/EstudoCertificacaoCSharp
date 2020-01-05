using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class TiposDeValor : IAulaItem
    {
        public void Executar()
        {
            int idade;
            idade = 30;
            Console.WriteLine(idade);

            int copiaIdade = idade;

            Console.WriteLine($"Idade: {idade}");
            Console.WriteLine($"Cópia idade: {copiaIdade}");

            idade = 23;
            
            Console.WriteLine($"Idade: {idade}");
            Console.WriteLine($"Cópia idade: {copiaIdade}");

            int? idade2 = null;
            System.Nullable<int> idade3 = null;
        }
    }
}
