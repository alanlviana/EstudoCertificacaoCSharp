using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace certificacao_csharp_pt6.Aula1
{
    class SerializandoObjetos : IExecutavel
    {
        public void Executar()
        {
            // Codigo do Primeiro Sistema
            var lojaFilmes = LojaFilmes.ObterLojaFilmes();
            var xmlSerializer = new XmlSerializer(typeof(LojaFilmes));

            using (var tw = new StringWriter())
            {
                xmlSerializer.Serialize(tw, lojaFilmes);
                Console.WriteLine(tw);
            }

            // Código do Segundo Sistema
        }

        
    }
}
