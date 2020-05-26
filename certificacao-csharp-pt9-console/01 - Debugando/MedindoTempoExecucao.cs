using certificacao_csharp_pt9_dados;
using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace certificacao_csharp_pt9_console._01___Debugando
{
    class MedindoTempoExecucao : IExecutavel
    {
        private readonly string DatabaseServer = @"(localdb)\ProjectsV13";
        private readonly string MasterDatabase = "master";
        private readonly string DatabaseName = "Cinema9";

        public async void Executar()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            CinemaDB cinema = new CinemaDB(DatabaseServer, MasterDatabase, DatabaseName);
            await cinema.CriarBancoDeDadosAsync();
            stopwatch.Stop();

            Console.WriteLine("Tempo para criação do banco de dados: " + stopwatch.ElapsedMilliseconds);

            var filmes = await cinema.GetFilmes();
            
            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"Relatório de Filmes");
            Console.WriteLine(new string('=',50));

            foreach (var filme in filmes)
            {
                Console.WriteLine($"Diretor: {filme.Diretor} \n Titulo: {filme.Titulo}");
                Console.WriteLine(new string('-', 50));

            }

        }
    }
}
