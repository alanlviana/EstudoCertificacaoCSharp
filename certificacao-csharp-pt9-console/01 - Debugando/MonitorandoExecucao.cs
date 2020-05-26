using certificacao_csharp_pt9_console._01___Debugando.Performance;
using certificacao_csharp_pt9_dados;
using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_pt9_console._01___Debugando
{
    class MonitorandoExecucao : IExecutavel
    {
        private readonly string DatabaseServer = @"(localdb)\ProjectsV13";
        private readonly string MasterDatabase = "master";
        private readonly string DatabaseName = "Cinema9";

        public async void Executar()
        {

            CinemaDB cinema = new CinemaDB(DatabaseServer, MasterDatabase, DatabaseName);
            await cinema.CriarBancoDeDadosAsync();
            Stopwatch stopwatch = new Stopwatch();

            while (true) {
                stopwatch.Start();
                await GerarRelatorio(cinema);
                stopwatch.Stop();

                RegistroPerformance(stopwatch.ElapsedTicks);
            }


        }

        private void RegistroPerformance(long elapsedTicks)
        {
            // Criar Categoria
            MonitoramentoPerformance.ConfigurarCategoria();

            MonitoramentoPerformance.ContadorRelatorio.IncrementBy(elapsedTicks);
            MonitoramentoPerformance.ContadorRelatorioBase.Increment();
        }

        private static async Task GerarRelatorio(CinemaDB cinema)
        {
            var filmes = await cinema.GetFilmes();

            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"Relatório de Filmes");
            Console.WriteLine(new string('=', 50));

            foreach (var filme in filmes)
            {
                Console.WriteLine($"Diretor: {filme.Diretor} \n Titulo: {filme.Titulo}");
                Console.WriteLine(new string('-', 50));

            }
        }
    }
}
