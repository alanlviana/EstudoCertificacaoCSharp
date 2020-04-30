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
    class BuscaRecursivaArquivo : IExecutavel
    {
        private const string CaminhoTeste = "Teste";

        public void Executar()
        {
            DirectoryInfo diretorioInicial = new DirectoryInfo("../../..");


            ListarDiretorios("../../..");

        }

        private void ListarDiretorios(string caminho)
        {
            DirectoryInfo diretorioInicial = new DirectoryInfo(caminho);

            foreach (var diretorioFilho in diretorioInicial.GetDirectories())
            {
                foreach(var csFile in diretorioFilho.GetFiles().Where(f => f.Extension == ".cs"))
                {
                    Console.WriteLine(csFile.FullName);
                }
                
                ListarDiretorios(diretorioFilho.FullName);


            }
        }
    }
}

