using certificacao_csharp_pt9_dados;
using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
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
            CinemaDB cinema = new CinemaDB(DatabaseServer, MasterDatabase, DatabaseName);
            await cinema.CriarBancoDeDadosAsync();
            var filmes = await cinema.GetFilmes();

            foreach(var filme in filmes)
            {
                Console.WriteLine(filme.Titulo);
            }

        }
    }
}
