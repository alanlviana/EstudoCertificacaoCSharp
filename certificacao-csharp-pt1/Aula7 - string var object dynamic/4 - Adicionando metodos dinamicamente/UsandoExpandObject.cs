
using Curso.Arquitetura.Menu;
using Newtonsoft.Json;
using System;
using System.Dynamic;

namespace certificacao_csharp_roteiro
{
    class UsandoExpandObject : IExecutavel
    {
        public void Executar()
        {
            var json = "{\"nome\": \"Programming in C#\", \"codigo\":\"70-483\"}";
            dynamic certificacao = JsonConvert.DeserializeObject<ExpandoObject>(json);
            certificacao.dificuldade = 4;
            certificacao.DobrarDificuldade = new Action(() =>
            {
                certificacao.dificuldade = certificacao.dificuldade * 2;
            });

            certificacao.DobrarDificuldade();
            ImprimeCertificacao(certificacao);
        }

        private void ImprimeCertificacao(dynamic certificacao)
        {
            System.Console.WriteLine(certificacao.nome);
            System.Console.WriteLine(certificacao.codigo);
            System.Console.WriteLine(certificacao.dificuldade);
            System.Console.WriteLine();
        }

    }

}