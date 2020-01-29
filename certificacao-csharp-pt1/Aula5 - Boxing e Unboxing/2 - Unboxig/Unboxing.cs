using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class Unboxing : IAulaItem
    {
        public void Executar()
        {
            int numero = 57;
            object caixa = numero;

            try
            {
                int unboxed = (int)caixa;
                Console.WriteLine("Unboxing ok");
            }catch(System.InvalidCastException e)
            {
                Console.WriteLine($"Falha ao realizar unboxing. {e.Message}");
            }
        }

        

    }
}
