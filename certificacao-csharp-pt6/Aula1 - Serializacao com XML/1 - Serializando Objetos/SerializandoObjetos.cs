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
            var lojaFilmes = ObterLojaFilmes();
            var xmlSerializer = new XmlSerializer(typeof(LojaFilmes));

            using (var tw = new StringWriter())
            {
                xmlSerializer.Serialize(tw, lojaFilmes);
                Console.WriteLine(tw);
            }

            // Código do Segundo Sistema
        }

        private object ObterLojaFilmes()
        {
            var frankDarabont = new Diretor("Frank Darabont", 1);
            var francisFordCoppola = new Diretor("Francis Ford Coppola", 1);
            var christopherNolan = new Diretor("Christopher Nolan", 1);

            var filmes = new List<Filme>() {
                new Filme(frankDarabont, "Um sonho de Liberdade", "1994"),
                new Filme(francisFordCoppola, "O poderoso chefão", "1972"),
                new Filme(christopherNolan, "Batman: O Cavaleiro das Trevas", "2008")
            };

            var diretores = new List<Diretor> {
                frankDarabont,
                francisFordCoppola,
                christopherNolan
            };

            var novaLoja = new LojaFilmes();
            novaLoja.Filmes = filmes;
            novaLoja.Diretores = diretores;

            return novaLoja;
        }
    }
}
