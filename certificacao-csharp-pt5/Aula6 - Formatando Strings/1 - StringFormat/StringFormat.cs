using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace certificacao_csharp_pt5.aula6
{
    class StringFormat : IExecutavel
    {
        private readonly string cartaTemplate = @"Bom dia {0},

Aguardo você no almoço de {1:D} ({1:dd/MM/yyyy}) em {2}.
O valor por pessoa é de {3:C}.

Atenciosamente,
{4}";

        public void Executar()
        {
            

            var destinatario = "José";
            var data = DateTime.Now;
            var endereco = "Rua dos Alfedeiros, N 4";
            var preco = 30;
            var remetente = "Maria";

            Console.WriteLine("Carta com Format");
            string cartaComFormat = string.Format(CultureInfo.GetCultureInfo("pt-BR"), cartaTemplate, destinatario, data, endereco, preco, remetente);
            Console.WriteLine(cartaComFormat);

            Console.WriteLine("Carta com Interpolação");
            string cartaComInterpolacao = $@"Bom dia {remetente},

Aguardo você no almoço de {data:D} ({data:dd/MM/yyyy}) em {endereco}.
O valor por pessoa é de {preco:C}.

Atenciosamente,
{destinatario}";
            Console.WriteLine(cartaComInterpolacao);

        }


    }
}
