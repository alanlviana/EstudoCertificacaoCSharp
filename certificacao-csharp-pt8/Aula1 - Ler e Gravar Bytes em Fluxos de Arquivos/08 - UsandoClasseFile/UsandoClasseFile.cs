using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Unicode;

namespace certificacao_csharp_pt8.Aula1
{
    class UsandoClasseFile: IExecutavel
    {
        private const string ArquivoFile = "ArquivoFile.txt";

        public void Executar()
        {
            var conteudo = "Conteúdo do meu arquivo (File)";
            File.WriteAllText(ArquivoFile, conteudo, Encoding.UTF8);

            var conteudoLido = File.ReadAllText(ArquivoFile);
            Console.WriteLine(conteudoLido);
        }
    }
}

