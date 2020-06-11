using ConsoleTables;
using Curso.Arquitetura.Menu;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace certificacao_csharp_pt11.Aula02
{
    class ParalelismoComLinq : IExecutavel
    {
        public void Executar()
        {
            var filmes = JsonConvert.DeserializeObject<IEnumerable<Filme>>(File.ReadAllText("filmes.json"));

            var consulta = from f in filmes
                           select new Filme
                           {
                               Titulo = f.Titulo,
                               Faturamento = f.Faturamento,
                               Orcamento = f.Orcamento,
                               Distribuidor = f.Distribuidor,
                               Genero = f.Genero,
                               Diretor = f.Diretor,
                               Lucro = f.Faturamento - f.Orcamento,
                               LucroPorcentagem = (f.Faturamento - f.Orcamento) / f.Orcamento
                           };

            filmes = consulta;

            var consultaFilmesAventura = from f in filmes
                                         where f.Genero == "Adventure"
                                         select f;

            GerarRelatorio("Filmes de aventura",consultaFilmesAventura);

            // Consulta com paralelismo
            var consultaFilmesAventuraComParalelismo = from f in filmes.AsParallel()
                                                      where f.Genero == "Adventure"
                                                     select f;

            GerarRelatorio("Filmes de aventura (em paralelo)", consultaFilmesAventuraComParalelismo);


            // Consulta com paralelismo forçado
            var consultaFilmesAventuraComParalelismoDefault = from f in filmes.AsParallel().WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                                                       where f.Genero == "Adventure"
                                                       select f;

            GerarRelatorio("Filmes de aventura (em paralelo forçado)", consultaFilmesAventuraComParalelismoDefault);

            // Consulta com paralelismo forçado com grau 4
            var consultaFilmesAventuraComParalelismoDefaultDegree = from f in filmes.AsParallel().WithExecutionMode(ParallelExecutionMode.ForceParallelism).WithDegreeOfParallelism(4)
                                                              where f.Genero == "Adventure"
                                                              select f;

            GerarRelatorio("Filmes de aventura (em paralelo forçado com 4 graus)", consultaFilmesAventuraComParalelismoDefaultDegree);


            // Consulta com paralelismo forçado com grau 4 ordenado
            var consultaFilmesAventuraComParalelismoDefaultDegreeOrdenado = from f in filmes.AsParallel().AsOrdered()
                                                                                    .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                                                                                    .WithDegreeOfParallelism(4)
                                                                                    
                                                                    where f.Genero == "Adventure"
                                                                    select f;

            GerarRelatorio("Filmes de aventura (em paralelo forçado com 4 graus ordenado)", consultaFilmesAventuraComParalelismoDefaultDegreeOrdenado);

            // Consulta com paralelismo forçado com grau 4 ordenado
            var imprimindoEmParalelo = from f in filmes.AsParallel()
                                                            where f.Genero == "Adventure"
                                                            select f;

            ImprimirEmParalelo("Imprimindo em paralelo", imprimindoEmParalelo);

        }

        private void ImprimirEmParalelo(string titulo, ParallelQuery<Filme> filmes)
        {
            Console.WriteLine();
            Console.WriteLine(titulo);
            Console.WriteLine();

            filmes.ForAll(f => Console.WriteLine(f.Titulo));
        }

        private void GerarRelatorio(string titulo, IEnumerable<Filme> filmes)
        {
            Console.WriteLine();
            Console.WriteLine(titulo);
            Console.WriteLine();
            
            var table = new ConsoleTable(new ConsoleTableOptions()
            {
                Columns = new []{"Item", "Faturamento", "Orçamento", "Lucro", "% Lucro"},
                EnableCount  = true
            });

            foreach(var filme in filmes)
            {
                table.AddRow(filme.Titulo, filme.Faturamento.ToString("C"), filme.Orcamento.ToString("C"), filme.Lucro.ToString("C"), filme.LucroPorcentagem);
            }

            table.Write(Format.Minimal);
        }
    }
}
