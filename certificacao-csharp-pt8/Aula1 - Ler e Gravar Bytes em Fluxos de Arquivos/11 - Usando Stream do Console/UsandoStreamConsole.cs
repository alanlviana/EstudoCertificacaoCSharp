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
    class UsandoStreamConsole : IExecutavel
    {

        public void Executar()
        {
            using (var fluxoEntrada = Console.OpenStandardInput())
            {
                var buffer = new byte[1204];
                while (true)
                {
                    var bytesLidos = fluxoEntrada.Read(buffer, 0, buffer.Length);
                    var textosDigitados = Encoding.UTF8.GetString(buffer, 0, bytesLidos);
                    Console.WriteLine("Texto capturado: "+textosDigitados);
                }
            }
        }
    }
}

