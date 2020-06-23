using Curso.Arquitetura.Menu;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt12.Aula01
{
    class ValidandoJSON : IExecutavel
    {
        public void Executar()
        {
            var json = "{\"Diretor\": \"James Cameron\", \"Titulo\": \"Titanic\", \"DuracaoMinutos\": 194}";
            var filme = JsonConvert.DeserializeObject<Filme>(json);
            Console.WriteLine(filme);

            try { 

            var jsonErrado = "{\"Diretor\": \"James Cameron\", \"Titulo\": \"Titanic\", \"DuracaoMinutos\": \"abc\"}";
            var filmeErrado = JsonConvert.DeserializeObject<Filme>(jsonErrado);
            Console.WriteLine(filmeErrado);
            }catch(JsonReaderException e)
            {
                Console.WriteLine("Falha ao ler o JSON: "+ e.Message);
            }

        }
    }
}
