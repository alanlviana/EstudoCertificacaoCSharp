using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class Enumeracoes : IAulaItem
    {
        public void Executar()
        {
            //const int SEGUNDA_FEIRA = 0;
            //const int TERCA_FEIRA = 1;
            //const int QUARTA_FEIRA = 2;
            //const int QUINTA_FEIRA = 3;
            //const int SEXTA_FEIRA = 4;
            //const int SABADO = 5;
            //const int DOMINGO = 6;

            DiasDaSemana diaDaSemana = DiasDaSemana.Segunda;
            DiasDeTrabalho diasDeTrabalho = DiasDeTrabalho.Terca | DiasDeTrabalho.Quinta | DiasDeTrabalho.Sexta;

            Console.WriteLine($"Dias de trabalho: {diasDeTrabalho}");
        }
        [Flags]
        enum DiasDeTrabalho
        {
            Segunda = 0,
            Terca = 1,
            Quarta = 2,
            Quinta = 4,
            Sexta = 8,
            Sabado = 16,
            Domingo = 32
        }

        enum DiasDaSemana : long
        {
            Segunda = 1,
            Terca,
            Quarta,
            Quinta,
            Sexta,
            Sabado,
            Domingo
        }
    }
}
