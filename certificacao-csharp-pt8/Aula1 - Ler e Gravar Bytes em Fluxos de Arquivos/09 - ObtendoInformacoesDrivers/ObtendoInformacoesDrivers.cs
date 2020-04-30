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
    class ObtendoInformacoesDrivers: IExecutavel
    {

        public void Executar()
        {
            //
            var drivers= DriveInfo.GetDrives();

            foreach(var drive in drivers)
            {
                Console.WriteLine($"Nome do Drive: {drive.Name}");
                if (!drive.IsReady)
                {
                    continue;
                }

                Console.WriteLine($"Status: {drive.IsReady}");
                Console.WriteLine($"Tipo: {drive.DriveType.ToString()}");
                Console.WriteLine($"Formato: {drive.DriveFormat}");
                Console.WriteLine($"Raiz: {drive.RootDirectory}");
                double bytes = drive.AvailableFreeSpace;
                Console.WriteLine($"Espaço livre(bytes): {bytes:N2} bytes");
                double kbytes = bytes / 1024;
                Console.WriteLine($"Espaço livre(KB): {kbytes:N2} KB");
                double megabytes = kbytes / 1024;
                Console.WriteLine($"Espaço livre(MB): {megabytes:N2} MB");
                double gigabyte = megabytes / 1024;
                Console.WriteLine($"Espaço livre(GB): {gigabyte:N2} GB");


            }
        }
    }
}

