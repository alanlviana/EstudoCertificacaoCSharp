using certificacao_csharp_pt6.Aula1;
using Curso.Arquitetura.Menu;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace certificacao_csharp_pt6.Aula3
{
    class DeserializacaoBinaria : IExecutavel
    {
        public void Executar()
        {
            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = new FileStream("LojaBinaria.bin", FileMode.OpenOrCreate, FileAccess.Read))
            {
                var loja = (LojaFilmes)binaryFormatter.Deserialize(fileStream);

                Console.WriteLine("Diretores:");
                loja.Diretores.ForEach(d => Console.WriteLine(d.Nome));

                Console.WriteLine("Filmes:");
                loja.Filmes.ForEach(f => Console.WriteLine(f.Titulo));

            }
        }
    }
}
