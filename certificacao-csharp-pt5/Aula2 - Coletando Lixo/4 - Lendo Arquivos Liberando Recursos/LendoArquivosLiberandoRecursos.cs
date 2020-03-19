using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace certificacao_csharp_pt5.aula2
{
    class LendoArquivosLiberandoRecursos : IExecutavel
    {
        public void Executar()
        {
            using (var leitor = new LeitorDeArquivo("C:\\Windows\\System32\notepad.exe"))
            {

                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();

            }

        }
    }

    class LeitorDeArquivo: IDisposable
    {
        public LeitorDeArquivo(string arquivo)
        {
            Arquivo = arquivo;

            Console.WriteLine("Abrindo arquivo:" + Arquivo);
        }

        public string Arquivo { get; }

        public string LerProximaLinha()
        {
            Console.WriteLine("Lendo próxima linha");
            return "linha do arquivo";
        }


        public void Dispose()
        {
            Console.WriteLine("Fechando arquivo.");

        }
    }

}
