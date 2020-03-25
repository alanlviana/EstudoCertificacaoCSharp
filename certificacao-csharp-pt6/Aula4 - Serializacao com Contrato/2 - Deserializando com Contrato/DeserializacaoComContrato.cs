using certificacao_csharp_pt6.Aula1;
using Curso.Arquitetura.Menu;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace certificacao_csharp_pt6.Aula4
{
    class DeserializacaoComContrato : IExecutavel
    {
        public void Executar()
        {
            var dataContractSerializer = new DataContractSerializer(typeof(LojaFilmes));
            using (var fileStream = new FileStream("LojaContrato.xml", FileMode.Open, FileAccess.Read))
            {
                var loja = (LojaFilmes)dataContractSerializer.ReadObject(fileStream);

                Console.WriteLine("Filmes:");
                Console.WriteLine();
                loja.Filmes.ForEach(f => Console.WriteLine(f.Titulo));

                Console.WriteLine("Diretores:");
                Console.WriteLine();
                loja.Diretores.ForEach(d => Console.WriteLine(d.Nome));

            }
        }
    }
}
