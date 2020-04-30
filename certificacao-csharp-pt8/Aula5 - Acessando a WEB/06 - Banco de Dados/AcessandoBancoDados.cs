using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace certificacao_csharp_pt8.Aula2
{
    class AcessandoBancoDados : IExecutavel
    {
        private const string ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Cinema;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private readonly string DatabaseServer = @"(localdb)\ProjectsV13";
        private readonly string MasterDatabase = "master";
        private readonly string DatabaseName = "Cinema";

        public async void Executar()
        {
            //await CriarBancoDeDadosAsync();

            try
            {
                await AlterarNomeDiretor("Quentin Tarantino", 1);
                await ImprimirFilmes();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            


        }

        private async Task AlterarNomeDiretor(string nomeDiretor, int diretorID)
        {
            using (var conexao = new SqlConnection(ConnectionString))
            {
                await conexao.OpenAsync();

                const string cmd = @"Update Diretores SET NOME  =  @nomeDiretor WHERE ID = @diretorID";
                using (var comando = new SqlCommand(cmd, conexao))
                {
                    comando.Parameters.AddWithValue("@nomeDiretor", nomeDiretor);
                    comando.Parameters.AddWithValue("@diretorID", diretorID);

                    int registros = await comando.ExecuteNonQueryAsync();
                    Console.WriteLine($"Linhas atualizadas {registros}");
                }

            }
        }

        private async Task ImprimirFilmes()
        {
            using (var conexao = new SqlConnection(ConnectionString))
            {
                await conexao.OpenAsync();
                using (var comando = new SqlCommand(@"SELECT d.Nome, f.Titulo
                                                        FROM Filmes as F
                                                       INNER JOIN Diretores as D on D.Id = F.DiretorId", conexao))
                {
                    using (var reader = await comando.ExecuteReaderAsync())
                    {
                        Console.WriteLine("Diretor \t Titulo");
                        while (await reader.ReadAsync())
                        {
                            var nome = reader.GetString("Nome");
                            var titulo = reader.GetString("Titulo");

                            Console.WriteLine($"{nome} \t {titulo}");
                        }
                    }


                }

            }
        }


        #region Banco de dados
        private async Task CriarBancoDeDadosAsync()
        {
            await CriarBancoAsync();
            await CriarTabelasAsync();
            await InserirRegistrosAsync();
        }

        private async Task CriarBancoAsync()
        {
            string sql = $@"IF EXISTS (SELECT * FROM sys.databases WHERE name = N'{DatabaseName}')
                    BEGIN
                        DROP DATABASE [{DatabaseName}]
                    END;
                    CREATE DATABASE [{DatabaseName}];";
            await ExecutarComandoAsync(sql, MasterDatabase);
        }

        private async Task CriarTabelasAsync()
        {
            string sql = $@"CREATE TABLE [dbo].[Diretores] (
                        [Id]   INT           IDENTITY (1, 1) NOT NULL,
                        [Nome] VARCHAR (255) NOT NULL
                    );
                    CREATE TABLE [dbo].[Filmes] (
                        [Id]        INT           IDENTITY (1, 1) NOT NULL,
                        [DiretorId] INT           NOT NULL,
                        [Titulo]    VARCHAR (255) NOT NULL,
                        [Ano]       INT           NOT NULL,
                        [Minutos]   INT           NOT NULL
                    );";
            await ExecutarComandoAsync(sql, DatabaseName);
        }

        private async Task InserirRegistrosAsync()
        {
            string sql = @"
                    INSERT Diretores (Nome) VALUES ('Quentin Jerome Tarantino');
                    INSERT Diretores (Nome) VALUES ('James Cameron');
                    INSERT Diretores (Nome) VALUES ('Tim Burton');

                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (1, 'Pulp Fiction', 1994,	154);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (1, 'Django Livre', 2012,	165);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (1, 'Kill Bill Volume 1', 2003,	111);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (2, 'Avatar', 2009,	162);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (2, 'Titanic', 1997,	194);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (2, 'O Exterminador do Futuro', 1984,	107);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (3, 'O Estranho Mundo de Jack', 1993,	76);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (3, 'Alice no País das Maravilhas', 2010,	108);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (3, 'A Noiva Cadáver', 2005,	77);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (3, 'A Fantástica Fábrica de Chocolate', 2005,	115);";
            await ExecutarComandoAsync(sql, DatabaseName);
        }

        private async Task ExecutarComandoAsync(string sql, string banco)
        {
            if (string.IsNullOrWhiteSpace(DatabaseServer))
            {
                throw new Exception("DatabaseServer precisa ser definido!");
            }


            try
            {
                using (SqlConnection conexao = new SqlConnection($"Server={DatabaseServer};Integrated security=SSPI;database={banco}"))
                {
                    conexao.Open();
                    using (var comando = new SqlCommand(sql, conexao))
                    {
                        await comando.ExecuteNonQueryAsync();
                    }
                }
                Console.WriteLine("Script executado com sucesso.");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion
    }
}
