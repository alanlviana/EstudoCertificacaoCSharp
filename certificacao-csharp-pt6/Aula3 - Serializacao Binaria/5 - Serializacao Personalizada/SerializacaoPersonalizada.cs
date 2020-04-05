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

namespace certificacao_csharp_pt6.Aula3
{
    class SerializacaoPersonalizada : IExecutavel
    {
        public void Executar()
        {
            LojaFilmes loja = LojaFilmes.ObterLojaFilmes();
            var serializer = new DataContractSerializer(typeof(LojaFilmes));

            using (var fileStream = new FileStream("LojaPersonalizada.xml", FileMode.OpenOrCreate, FileAccess.Write))
            {
                serializer.WriteObject(fileStream, loja);
            }
        }
    }
}
