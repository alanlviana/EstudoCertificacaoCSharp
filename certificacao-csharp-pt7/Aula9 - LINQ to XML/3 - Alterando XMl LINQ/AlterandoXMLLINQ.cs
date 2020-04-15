using Curso.Arquitetura.Menu;
using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace certificacao_csharp_pt7.Aula9
{
    class AlterandoXMLLINQ : IExecutavel
    {

        public void Executar()
        {
            var xml = @"
                <Filmes>
                    <Filme>
                        <Diretor>Quentin Tarantino</Diretor>
                        <Titulo>Pulp Fiction</Titulo>
                        <Minutos>154</Minutos>
                    </Filme>
                    <Filme>
                        <Diretor>James Cameron</Diretor>
                        <Titulo>Avatar</Titulo>
                        <Minutos>162</Minutos>
                    </Filme>
                </Filmes>";

            var document = XDocument.Parse(xml);

            var pulpFiction = (from filme in document.Descendants("Filme")
                             where filme.Element("Titulo").Value.Equals("Pulp Fiction")
                             select filme).FirstOrDefault();

            pulpFiction.Add(new XElement("Genero", "Drama"));


            var avatar = (from filme in document.Descendants("Filme")
                               where filme.Element("Titulo").Value.Equals("Avatar")
                               select filme).FirstOrDefault();

            avatar.Add(new XElement("Genero", "Ficção Científica"));

            Console.WriteLine(document.ToString()); 
                                     


        }
        
    }
}
