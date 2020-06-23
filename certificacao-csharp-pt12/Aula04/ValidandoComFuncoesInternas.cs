using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace certificacao_csharp_pt12.Aula04
{
    class ValidandoComFuncoesInternas : IExecutavel
    {
        public void Executar()
        {
            
            bool valido = false;
            var valorLido = "";
            int numero = 0;
            do
            {
                Console.WriteLine("Digite um valor inteiro: ");

                valorLido = Console.ReadLine();

                valido = !string.IsNullOrWhiteSpace(valorLido); 
                valido = valido && int.TryParse(valorLido, out numero); 

                if (!valido)
                {
                    Console.WriteLine("Entrada inválida!");
                }

            } while (!valido);

            Console.WriteLine($"O dobro de {numero} é {numero*2}");

        }
    }
}
