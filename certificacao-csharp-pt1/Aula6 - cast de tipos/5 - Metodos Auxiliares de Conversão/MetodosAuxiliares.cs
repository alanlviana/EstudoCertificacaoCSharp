using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class MetodosAuxiliares : IAulaItem
    {
        public void Executar()
        {
            string textoDigitado = "123";
            Console.WriteLine("convertendo: " + textoDigitado);
            //int numeroConvertido = textoDigitado as int; // The as operator must be user with a reference type or nullable type ('int' is a nom-nullable value type)
            //int numeroConvertido = (int)textoDigitado as int; // Cannot convert type 'string' to 'int'
            int numeroConvertido = int.Parse(textoDigitado);

            Console.WriteLine("Número convertido: "+numeroConvertido);

            textoDigitado = "abc";
            Console.WriteLine("convertendo: " + textoDigitado);
            //numeroConvertido = int.Parse(textoDigitado); // A cadeia de caracteres de entrada não estava em um formato correto.
            if (int.TryParse(textoDigitado, out numeroConvertido))
            {
                Console.WriteLine("Número convertido: " + numeroConvertido);
            }
            else
            {
                Console.WriteLine("textoDigitado não é um número");
            }

            textoDigitado = "123,45";
            Console.WriteLine("convertendo: " + textoDigitado);
            if (decimal.TryParse(textoDigitado, out decimal valorConvertido)) {
                Console.WriteLine("valorConvertido: "+valorConvertido);
            }
            else
            {
                Console.WriteLine("textoDigitado não é um número");
            }

            textoDigitado = "R$ 123,45";
            Console.WriteLine("convertendo: "+textoDigitado);
            if (decimal.TryParse(textoDigitado,
                 System.Globalization.NumberStyles.Currency, 
                 System.Globalization.CultureInfo.CurrentCulture, 
                 out valorConvertido))
            {
                Console.WriteLine("valorConvertido: " + valorConvertido);
            }
            else
            {
                Console.WriteLine("textoDigitado não é um número");
            }


        }

    }

}