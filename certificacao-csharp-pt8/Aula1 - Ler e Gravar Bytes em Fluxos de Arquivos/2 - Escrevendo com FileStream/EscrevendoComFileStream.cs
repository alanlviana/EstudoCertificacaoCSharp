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
    class EscrevendoComFileStream : IExecutavel
    {
        public void Executar()
        {
            using (FileStream fluxoSaida = new FileStream("FluxoSaida.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                var mensagem = "Olá, Alura!";

                // String to Byte[] com LINQ
                //var arrayBytes = mensagem.Select(c => Convert.ToByte(c)).ToArray();


                var arrayBytes = Encoding.UTF8.GetBytes(mensagem);

                fluxoSaida.Write(arrayBytes, 0, arrayBytes.Length);

                fluxoSaida.Flush();
            }

            using (FileStream fluxoEntrada = new FileStream("FluxoSaida.txt", FileMode.Open, FileAccess.Read))
            {
                Byte[] bytesLidos = new byte[fluxoEntrada.Length];
                fluxoEntrada.Read(bytesLidos, 0, bytesLidos.Length);

                var mensagem = Encoding.UTF8.GetString(bytesLidos);

                Console.WriteLine("Arquivo lido:");
                Console.WriteLine(mensagem);

            }



        }
    }
}
