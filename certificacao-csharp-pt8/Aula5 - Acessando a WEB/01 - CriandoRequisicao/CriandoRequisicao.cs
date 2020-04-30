using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Text;

namespace certificacao_csharp_pt8.Aula2
{
    class CriandoRequisicao : IExecutavel
    {
        public void Executar()
        {
            WebRequest request = WebRequest.Create(@"https://www.caelum.com.br/");
            WebResponse response = request.GetResponse();
            using (var streamResponse = response.GetResponseStream())
            {
                var conteudo = new StreamReader(streamResponse).ReadToEnd();
                Console.WriteLine(conteudo);

            }

        }

    }
}
