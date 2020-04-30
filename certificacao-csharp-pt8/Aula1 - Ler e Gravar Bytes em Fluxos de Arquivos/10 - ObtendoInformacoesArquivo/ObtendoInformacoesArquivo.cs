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
    class ObtendoInformacoesArquivo : IExecutavel
    {

        public void Executar()
        {
            File.WriteAllText("InfoArquivo.txt", "Arquivo Inicial");

            FileInfo info = new FileInfo("InfoArquivo.txt");

            
            Console.WriteLine($"Nome: {info.Name} ");
            Console.WriteLine($"Nome completo: {info.FullName}");
            Console.WriteLine($"Atributos: {info.Attributes}");
            info.Attributes = info.Attributes | FileAttributes.ReadOnly;
            Console.WriteLine($"Atributos: {info.Attributes}");
            info.Attributes = info.Attributes & ~FileAttributes.ReadOnly;
            Console.WriteLine($"Atributos: {info.Attributes}");

        }
    }
}

