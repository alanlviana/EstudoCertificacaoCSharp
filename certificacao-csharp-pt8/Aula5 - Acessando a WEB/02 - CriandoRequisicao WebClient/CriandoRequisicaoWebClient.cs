using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Text;

namespace certificacao_csharp_pt8.Aula2
{
    class CriandoRequisicaoWebClient : IExecutavel
    {
        public void Executar()
        {
            string conteudo = new WebClient().DownloadString(@"https://www.caelum.com.br/");
            Console.WriteLine(conteudo);
        }

    }
}
