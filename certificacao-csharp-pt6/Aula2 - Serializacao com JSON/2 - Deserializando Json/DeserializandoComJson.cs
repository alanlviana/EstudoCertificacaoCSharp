using certificacao_csharp_pt6.Aula1;
using Curso.Arquitetura.Menu;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace certificacao_csharp_pt6.Aula2
{
    class DeserializandoComJson : IExecutavel
    {
        private const string NOME_ARQUIVO_LOJA_FILMES = "LojaFilme.json";

        public void Executar()
        {
            if (!File.Exists(NOME_ARQUIVO_LOJA_FILMES))
            {
                Console.WriteLine("Arquivo não existe.");
            }


            using (var streamReader = new StreamReader(NOME_ARQUIVO_LOJA_FILMES))
            {
                var jsonLoja = streamReader.ReadToEnd();

                var loja = JsonConvert.DeserializeObject<LojaFilmes>(jsonLoja);
                
                Console.WriteLine("Diretores:");
                loja.Diretores.ForEach(d => Console.WriteLine(d.Nome)); ;
                
                Console.WriteLine("Filmes:");
                loja.Filmes.ForEach(f => Console.WriteLine(f.Titulo)); ;

            }
        }
    }
}
