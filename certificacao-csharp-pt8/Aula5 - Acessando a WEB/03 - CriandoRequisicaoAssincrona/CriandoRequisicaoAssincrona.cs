using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace certificacao_csharp_pt8.Aula2
{
    class CriandoRequisicaoAssincrona : IExecutavel
    {
        public async void Executar()
        {
            string conteudo = await LerTextoDoSite(@"https://www.caelum.com.br/");
            Console.WriteLine(conteudo);
        }

        public async Task<string> LerTextoDoSite(string site)
        {
            var task = await new WebClient().DownloadStringTaskAsync(site);
            return task;

        }

    }
}
