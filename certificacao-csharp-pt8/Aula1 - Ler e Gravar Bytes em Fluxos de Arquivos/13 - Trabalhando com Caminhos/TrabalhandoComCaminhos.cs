using Curso.Arquitetura.Menu;
using Microsoft.VisualBasic.FileIO;
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
    class TrabalhandoComCaminhos : IExecutavel
    {
        private const string CaminhoTeste = "Teste";

        public void Executar()
        {
            var caminhoMeusDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Console.WriteLine(caminhoMeusDocumentos);

            var caminhoCompleto = Path.Combine(caminhoMeusDocumentos, "Alura.txt");
            Console.WriteLine(caminhoCompleto);
            var somenteDiretorio = Path.GetDirectoryName(caminhoCompleto);
            Console.WriteLine(somenteDiretorio);
            var somenteArquivo = Path.GetFileName(caminhoCompleto);
            Console.WriteLine(somenteArquivo);
            var extensaoArquivo = Path.GetExtension(caminhoCompleto);
            Console.WriteLine(extensaoArquivo);

            var outroArquivo = Path.ChangeExtension(caminhoCompleto, ".jpg");
            Console.WriteLine(outroArquivo);
        }
    }
}

