﻿using certificacao_csharp_pt9_dados;
using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace certificacao_csharp_pt9_console._01___Debugando
{
    class VersaoAssembly : IExecutavel
    {
        private readonly string DatabaseServer = @"(localdb)\ProjectsV13";
        private readonly string MasterDatabase = "master";
        private readonly string DatabaseName = "Cinema9";

        public async void Executar()
        {
            TraceListener traceListener = new TextWriterTraceListener("Trace.txt");
            Trace.AutoFlush = true;
            Trace.Listeners.Add(traceListener);

            CinemaDB cinema = new CinemaDB(DatabaseServer, MasterDatabase, DatabaseName);
            await cinema.CriarBancoDeDadosAsync();
            var filmes = await cinema.GetFilmes();
            
            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"Relatório de Filmes");
            Console.WriteLine(new string('=',50));

            foreach (var filme in filmes)
            {
                Console.WriteLine($"Diretor: {filme.Diretor} \n Titulo: {filme.Titulo}");
                Console.WriteLine(new string('-', 50));

            }

            Trace.Listeners.Remove(traceListener);

        }
    }
}
