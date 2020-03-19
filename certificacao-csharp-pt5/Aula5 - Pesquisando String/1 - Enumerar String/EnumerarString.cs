using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt5.aula4
{
    class EnumerarString : IExecutavel
    {

        private static readonly string TEXTO = "Que documento é esse? O documento é simplesmente uma string que é fornecida pelo método GetDocumento. Então nós temos aqui a string que é retornada por esse método. Estou selecionando aqui a string, ela tem cerca de dois parágrafos, eu acho, mais ou menos.";

        public void Executar()
        {
            foreach(var c in TEXTO)
            {
                if (char.IsPunctuation(c))
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;

                }

                Console.Write(c);
                Console.ResetColor();
            }
        }


    }
}
