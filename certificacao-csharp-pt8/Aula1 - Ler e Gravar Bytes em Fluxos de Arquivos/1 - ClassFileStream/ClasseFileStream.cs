using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace certificacao_csharp_pt8.Aula1
{
    class ClasseFileStream : IExecutavel
    {
        public void Executar()
        {
            var diretores = new FileStream("Diretores.txt", FileMode.Open, FileAccess.Read);
            var bytes = new byte[10];

            diretores.Read(bytes, 0, 10);
            ImprimirBytes(bytes);

            diretores.Read(bytes, 0, 10);
            ImprimirBytes(bytes);

            diretores.Read(bytes, 0, 2);
            ImprimirBytes(bytes);

            diretores.Read(bytes, 0, 2);
            ImprimirBytes(bytes);
        }

        private static void ImprimirBytes(byte[] bytes)
        {
            foreach (var charByte in bytes)
            {
                Console.WriteLine(charByte + " - " + Convert.ToChar(charByte) + "(" + charByte.ToString("X") + ")");
            }
        }
    }
}
