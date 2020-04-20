using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Unicode;

namespace certificacao_csharp_pt8.Aula1
{
    class DesafioFileStream : IExecutavel
    {
        public void Executar()
        {
            using (var fs = new FileStream("Alura.txt", FileMode.Open, FileAccess.Read))
            {

                var buffer = new byte[1024];
                var encoding = Encoding.ASCII;

                var quantidadesBytesLidos = fs.Read(buffer, 0, 1024);
                var conteudoArquivo = encoding.GetString(buffer, 0, quantidadesBytesLidos);

                Console.WriteLine(conteudoArquivo);
            }

        }
    }
}
