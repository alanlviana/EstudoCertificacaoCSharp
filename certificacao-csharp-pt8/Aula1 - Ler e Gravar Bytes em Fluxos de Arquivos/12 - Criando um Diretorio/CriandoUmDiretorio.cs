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
    class CriandoUmDiretorio : IExecutavel
    {
        private const string CaminhoTeste = "Teste";

        public void Executar()
        {
            Console.WriteLine("Métodos com Directory");
            Console.WriteLine("Criando diretório.");
            Directory.CreateDirectory(CaminhoTeste);

            var existe = Directory.Exists(CaminhoTeste);
            Console.WriteLine($"Diretório {CaminhoTeste} existe? {existe}");

            Console.WriteLine("Apagando diretório.");
            Directory.Delete(CaminhoTeste);
            existe = Directory.Exists(CaminhoTeste);

            Console.WriteLine($"Diretório {CaminhoTeste} ainda existe? {existe}");

            Console.WriteLine();
            Console.WriteLine("Métodos com DirectoryInfo");

            var diretorio = new DirectoryInfo(CaminhoTeste);

            Console.WriteLine("Criando um diretório");
            diretorio.Create();
            existe = diretorio.Exists;
            Console.WriteLine($"Diretório {CaminhoTeste} existe? {existe}");
            Console.WriteLine($"Atribbutos de {CaminhoTeste}: {diretorio.Attributes}");
            Console.WriteLine($"Ultimo acesso de {CaminhoTeste}: {diretorio.LastAccessTime}");
            Console.WriteLine("Apagando diretório.");
            diretorio.Delete();

            diretorio.Refresh();
            existe = diretorio.Exists;
            Console.WriteLine($"Diretório {CaminhoTeste} ainda existe? {existe}");

        }
    }
}

