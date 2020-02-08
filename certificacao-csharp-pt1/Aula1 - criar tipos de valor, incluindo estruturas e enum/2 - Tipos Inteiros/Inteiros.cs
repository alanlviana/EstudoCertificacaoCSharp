using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class TiposInteiros : IExecutavel
    {
        public void Executar()
        {
            int idade = 15;
            //idade = 15.5;

            char resposta = 's'; // System.Char

            byte nivelDeAzul = 0xFF; // = 255 em decimal
            //nivelDeAzul = -3;

            short passageirosVoos = 230; // System.Int16
            passageirosVoos = -7;

            int populacao = 1500; // System.Int32
            populacao = -2300;

            long populacaoDoBrasil = 207_660_929; // +/- 207 milhões

            sbyte nivelDeBrilho = -127; // System.SByte;
            ushort passageirosNavio = 599; // System.UInt16
            uint estoque = 1500;// System.UInt32;

            ulong populacaoDoMundo = 7_000_000_000;

            Console.WriteLine($"{nameof(idade)} = {idade}");
            Console.WriteLine($"{nameof(resposta)} = {resposta}");
            Console.WriteLine($"{nameof(nivelDeAzul)} = {nivelDeAzul}");
            Console.WriteLine($"{nameof(passageirosVoos)} = {passageirosVoos}");
            Console.WriteLine($"{nameof(populacao)} = {populacao}");
            Console.WriteLine($"{nameof(populacaoDoBrasil)} = {populacaoDoBrasil}");
            Console.WriteLine($"{nameof(nivelDeBrilho)} = {nivelDeBrilho}");
            Console.WriteLine($"{nameof(passageirosNavio)} = {passageirosNavio}");
            Console.WriteLine($"{nameof(estoque)} = {estoque}");
            Console.WriteLine($"{nameof(populacaoDoMundo)} = {populacaoDoMundo}");


        }
    }
}
