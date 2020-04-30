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
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace certificacao_csharp_pt8.Aula2
{
    class ConsumindoJson : IExecutavel
    {

        public async void Executar()
        {
            var url = "http://viacep.com.br/ws/04101300/json/";


            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var stringJson = await response.Content.ReadAsStringAsync();
                var endereco = JsonSerializer.Deserialize<EnderecoViaCep>(stringJson);

                Console.WriteLine($"CEP = {endereco.cep}");
                Console.WriteLine($"Logradouro = {endereco.logradouro}");
                Console.WriteLine($"Complemento = {endereco.complemento}");
                Console.WriteLine($"Bairro = {endereco.bairro}");
                Console.WriteLine($"Localidade = {endereco.localidade}");
                Console.WriteLine($"UF = {endereco.uf}");
                Console.WriteLine($"Unidade = {endereco.unidade}");
                Console.WriteLine($"Ibge = {endereco.ibge}");
                Console.WriteLine($"GIA = {endereco.gia}");
            
            }

        }

    }

    class EnderecoViaCep
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string unidade { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }

    }
}
