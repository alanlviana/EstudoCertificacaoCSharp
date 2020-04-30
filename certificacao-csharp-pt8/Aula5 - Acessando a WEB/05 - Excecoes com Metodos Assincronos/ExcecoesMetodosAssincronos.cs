using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace certificacao_csharp_pt8.Aula2
{
    class ExcecoesMetodosAssincronos : IExecutavel
    {
        public async void Executar()
        {

            try
            {
                await GravarArquivoQueNaoExiste(@"https://www.caelum.com.br/");
            }catch(Exception e)
            {
                Console.WriteLine("Falha ao gravar arquivo: "+ e.Message);
            }

        }

        private async Task GravarArquivoQueNaoExiste(string linha)
        {
            using (var fileStream = new FileStream("404.txt", FileMode.Open, FileAccess.ReadWrite))
            {
                var bytes = Encoding.UTF8.GetBytes(linha);

                await fileStream.WriteAsync(bytes);
            }
        }
    }
}
