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
    class BinaryWriterStreamWriter : IExecutavel
    {
        public void Executar()
        {
            // Escrita
            
            using(var fileStream = new FileStream("TesteBinario.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                using(var binaryWriter = new BinaryWriter(fileStream))
                {
                    binaryWriter.Write(123456789);
                }
            }

            using (var fileStream = new FileStream("TesteNaoBinario.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.Write(123456789);
                }
            }

            // Leitura
            using (var fileStream = new FileStream("TesteBinario.txt", FileMode.Open, FileAccess.Read))
            {
                using (var binaryReader = new BinaryReader(fileStream))
                {
                    var value = binaryReader.ReadInt32();
                    Console.WriteLine("Leitura TesteBinario.txt:");
                    Console.WriteLine(value);
                }
            }

            using (var fileStream = new FileStream("TesteNaoBinario.txt", FileMode.Open, FileAccess.Read))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    var value = streamReader.ReadToEnd();

                    Console.WriteLine("Leitura TesteNaoBinario.txt:");
                    Console.WriteLine(value);
                }
            }
        }
    }
}

