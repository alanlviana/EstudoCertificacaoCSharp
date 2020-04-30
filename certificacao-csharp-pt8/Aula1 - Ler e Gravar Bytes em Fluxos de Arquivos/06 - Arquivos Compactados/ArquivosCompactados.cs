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
    class ArquivosCompactados : IExecutavel
    {
        public void Executar()
        {
            using (var fluxoArquivoZip = new FileStream("Texto.zip", FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (GZipStream compactador = new GZipStream(fluxoArquivoZip, CompressionMode.Compress))
                {
                    using (var streamWriter = new StreamWriter(compactador))
                    {
                        streamWriter.Write("Olá Alura!");
                    }
                }
            }

            using (var fluxoArquivoZip = new FileStream("Texto.zip", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (GZipStream descompactador = new GZipStream(fluxoArquivoZip,CompressionMode.Decompress))
                {
                    using (var streamReader = new StreamReader(descompactador))
                    {
                        var mensagem = streamReader.ReadToEnd();
                        Console.WriteLine(mensagem);
                    }
                }
            }
        }
    }
}

