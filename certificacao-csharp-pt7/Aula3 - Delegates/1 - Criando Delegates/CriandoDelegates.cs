using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Xml.Schema;

namespace certificacao_csharp_pt7.Aula3
{
    class CriandoDelegates : IExecutavel
    {
        delegate int OperacaoMatematica(int x, int y);

        public void Executar()
        {
            var x = 3;
            Console.WriteLine("x = 3");
            var y = 2;
            Console.WriteLine("y = 2");

            Func<int,int,int> operacaoMatematica1 = Somar;
            OperacaoMatematica operacaoMatematica2 = Somar;


            Console.WriteLine($"Somar({x},{y}) = {operacaoMatematica2(x,y)}");

            operacaoMatematica1 = Subtrair;
            Console.WriteLine($"Subtrair({x},{y}) = {operacaoMatematica1(x,y)}");

            operacaoMatematica1 = (x, y) => x*y;
            Console.WriteLine($"Multiplicar({x},{y}) = {operacaoMatematica1(x, y)}");

            operacaoMatematica1 = (x, y) => (int)Math.Pow(x,y);
            Console.WriteLine($"Potenciacao({x},{y}) = {operacaoMatematica1(x, y)}");

            Action<string> Escrever = Console.WriteLine;
            Escrever("Escrevendo mensagem com Action");

        }

        int Somar(int x, int y)
        {
            return x + y;
        }

        int Subtrair(int x, int y)
        {
            return x - y;
        }

    }
}
