using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;

namespace certificacao_csharp_pt12.Aula03
{
    class ValidandoEntradaComExpressaoRegular : IExecutavel
    {
        public void Executar()
        {
            var entrada1 = "CSharp Java Python Ruby Swift Scala ObjectiveC";
            var saida1 = entrada1.Replace(' ', ',');
            Console.WriteLine(entrada1);
            Console.WriteLine("Linguagens separadas por virgula:");
            Console.WriteLine(saida1);
            Console.WriteLine();

            var entrada2 = "CSharp     Java     Python     Ruby   Swift   Scala    ObjectiveC";
            Console.WriteLine(entrada2);
            var saida2 = Regex.Replace(entrada2, " +", ",");
            Console.WriteLine("Linguagens separadas por virgula (Regex):");
            Console.WriteLine(saida2);
            Console.WriteLine();

            var entrada3 = "123:O Exterminador do Futuro:1984:107";

            var padrao = "^[0-9]+:([a-z]|[A-Z]|[0-9]| )+:[0-9][0-9][0-9][0-9]:[0-9]+$";

            bool registroValido = Regex.IsMatch(entrada3, padrao);
            if (registroValido)
            {
                Console.WriteLine("O registro é válido.");
            }
            else
            {
                Console.WriteLine("O registro não é válido.");
            }


        }
    }
}
