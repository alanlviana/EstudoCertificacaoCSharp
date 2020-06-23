using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;

namespace certificacao_csharp_pt12.Aula03
{
    class ValidarURLComExpressaoRegular : IExecutavel
    {
        public void Executar()
        {
            var urls = new List<String> {
                "http://google.com",
                "http://microsoft.com",
                "http://drive.google.com",
                "http://www.uol.com",
                "facebook.com",
                "instragram.com",
                "whatsapp.com",
            };
            var url = String.Join(',', urls.ToArray());

            var resultados = new List<String>();

            var padrao = @"http://(www\.)?([^\\.]+)\.com";
            var regexUrl = new Regex(padrao, RegexOptions.Compiled);
            var correspondencias = regexUrl.Matches(url);
            Console.WriteLine($"URLS: {url}");


            foreach(Match correspondencia in correspondencias)
            {
                resultados.Add(correspondencia.Value);
            }

            foreach(var item in resultados)
            {
                Console.WriteLine(item);
            }
        }
    }
}
