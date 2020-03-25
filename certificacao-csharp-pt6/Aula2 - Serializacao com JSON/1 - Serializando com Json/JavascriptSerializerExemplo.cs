using certificacao_csharp_pt6.Aula1;
using Curso.Arquitetura.Menu;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace certificacao_csharp_pt6.Aula2
{
    class JavascriptSerializerExemplo : IExecutavel
    {
        public void Executar()
        {
            var loja = LojaFilmes.ObterLojaFilmes();
            var jsonLoja = JsonConvert.SerializeObject(loja,Formatting.Indented);
            Console.WriteLine(jsonLoja);

            File.WriteAllText("LojaFilme.json", jsonLoja);
        }
    }
}
