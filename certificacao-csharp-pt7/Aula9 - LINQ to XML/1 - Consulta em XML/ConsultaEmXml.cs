using Curso.Arquitetura.Menu;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace certificacao_csharp_pt7.Aula9
{
    class ConsultaEmXml : IExecutavel
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

            var listaFilme = from filme in document.Descendants("Filme")
                             let Diretor = filme.Element("Diretor").Value
                             let Titulo = filme.Element("Titulo").Value
                             let Minutos = filme.Element("Minutos").Value
                             where Titulo.StartsWith("A")
                             select new
                             {
                                 Diretor,
                                 Titulo,
                                 Minutos
                             };

            foreach(var filme in listaFilme)
            {
                System.Console.WriteLine($"Diretor: {filme.Diretor} \t Titulo: {filme.Titulo} \t Minutos: {filme.Minutos}");
            }
                                     


        }
        
    }
}
