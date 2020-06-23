using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace certificacao_csharp_pt12.Aula07
{
    class CheckSum : IExecutavel
    {
        public void Executar()
        {
            ExibirChecksum("Olá mundo!");
            ExibirHash("Olá mundo!");
            ExibirHash32Bits("Olá mundo!");
            Console.WriteLine();

            ExibirChecksum("Alura cursos online!");
            ExibirHash("Alura cursos online!");
            ExibirHash32Bits("Alura cursos online!");

        }

        private void ExibirHash32Bits(string origem)
        {
            Console.WriteLine("O Hash de '{0}' é:", origem);

            byte[] hash32 = CalcularHash32(origem);

            foreach(var c in hash32)
            {
                Console.Write("{0:X}", c);
            }
            Console.WriteLine();
        }

        private byte[] CalcularHash32(string origem)
        {
            HashAlgorithm sha1 = SHA256.Create();
            var bytesOrigem = UTF8Encoding.UTF8.GetBytes(origem);
            return sha1.ComputeHash(bytesOrigem);
        }

        private void ExibirHash(string origem)
        {
            Console.WriteLine("O Hash de {0} é {1:X}", origem, CalcularHash(origem));

        }

        private int CalcularHash(string origem)
        {
            return origem.GetHashCode();
        }

        private void ExibirChecksum(string origem)
        {
            Console.WriteLine("O checksum de {0} é {1}", origem, CalcularChecksum(origem));
        }

        private int CalcularChecksum(string origem)
        {
            int soma = 0;

            foreach(var c in origem){
                soma += c;
            }
            return soma;
        }
    }
}
