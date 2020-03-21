using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace certificacao_csharp_pt6.Aula1
{
    class DeserializandoArquivos : IExecutavel
    {
        private const string NOME_ARQUIVO_LOJA_FILME = "LojaFilmes.xml";

        public void Executar()
        {
            if (!File.Exists(NOME_ARQUIVO_LOJA_FILME))
            {
                Console.WriteLine("Arquivo para importação não encontrado.");
                return;
            }

            using (var fileStream = new FileStream(NOME_ARQUIVO_LOJA_FILME, FileMode.Open, FileAccess.Read))
            {
                var xmlSerializer = new XmlSerializer(typeof(LojaFilmes));
                var lojaFilme = (LojaFilmes)xmlSerializer.Deserialize(fileStream);

                foreach(var filme in lojaFilme.Filmes)
                {
                    Console.WriteLine($"Nome: {filme.Titulo}, Diretor: {filme.Diretor.Nome}");
                }
            }
        }
    }
}
