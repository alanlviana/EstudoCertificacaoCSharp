using ConsoleTables;
using Curso.Arquitetura.Menu;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_pt11.Aula06
{
    class TratamentoExcecaoAsyncAwait:IExecutavel
    {
        public async void Executar()
        {
            try
            {
                await PrepararRelatorio("fislmes.json");
            }catch(Exception e)
            {
                Console.WriteLine("Ocorreu um erro:");
                Console.WriteLine(e);
            }


        }

        public async Task PrepararRelatorio(string nomeArquivo)
        {
            var json = await LerArquivoJson(nomeArquivo);
            var filmes = JsonConvert.DeserializeObject<List<Filme>>(json);

            GerarRelatorio("Lista de Filmes", filmes);
        }

        private static async Task<string> LerArquivoJson(string nomeArquivo)
        {
            return await File.ReadAllTextAsync(nomeArquivo);
        }

        private void GerarRelatorio(string titulo, IEnumerable<Filme> filmes)
        {
            Console.WriteLine();
            Console.WriteLine(titulo);
            Console.WriteLine();

            var table = new ConsoleTable(new ConsoleTableOptions()
            {
                Columns = new[] { "Item", "Faturamento", "Orçamento", "Lucro", "% Lucro" },
                EnableCount = true
            });

            foreach (var filme in filmes)
            {
                table.AddRow(filme.Titulo, filme.Faturamento.ToString("C"), filme.Orcamento.ToString("C"), filme.Lucro.ToString("C"), filme.LucroPorcentagem);
            }

            table.Write(Format.Minimal);
        }
    }
}
