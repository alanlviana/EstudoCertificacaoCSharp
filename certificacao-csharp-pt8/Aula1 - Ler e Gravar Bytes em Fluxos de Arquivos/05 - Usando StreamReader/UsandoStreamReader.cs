using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Unicode;

namespace certificacao_csharp_pt8.Aula1
{
    class UsandoStreamReader : IExecutavel
    {
        public void Executar()
        {
            using(var streamReader = new StreamReader("ArquivoSaidaStreamWriter.txt")){
                var mensagem = streamReader.ReadToEnd();
                Console.WriteLine(mensagem);
            }
        }
    }
}
