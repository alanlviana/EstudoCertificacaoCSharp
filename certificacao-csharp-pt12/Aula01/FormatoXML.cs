using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace certificacao_csharp_pt12.Aula01
{
    class FormatoXML : IExecutavel
    {
        public void Executar()
        {
            var filme = new Filme(diretor: "Tim Burton", titulo: "A fantástica Fábrica de Chocolate", duracaoMinutos: 115);

            XmlSerializer serializador = new XmlSerializer(typeof(Filme));
            TextWriter writer = new StringWriter();
            serializador.Serialize(writer, filme);
            writer.Close();

            string filmeXml = writer.ToString();
            Console.WriteLine("Filme XML:");
            Console.WriteLine(filmeXml);

            TextReader reader = new StringReader(filmeXml);

            var filmeConvertido = serializador.Deserialize(reader) as Filme;
            Console.WriteLine("Filme convertido:");
            Console.WriteLine(filmeConvertido);
        }
    }
}
