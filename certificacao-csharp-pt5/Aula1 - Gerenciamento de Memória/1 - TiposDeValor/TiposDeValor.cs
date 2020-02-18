using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt5
{
    class TiposDeValor : IExecutavel
    {
        public void Executar()
        {
            // Não Existe nada na pilha
            Metodo1();
        }

        public void Metodo1()
        {
            //_________Metodo1________
            //|                       |
            //|                       |
            //|                       |
            //|                       |
            //-------------------------
            Metodo2(2);
        }

        public void Metodo2(int valor)
        {
            //_________Metodo2________
            //| valor                 |
            //| multiplicador         |
            //|                       |
            //|                       |
            //-------------------------
            //_________Metodo1________
            //|                       |
            //|                       |
            //|                       |
            //|                       |
            //-------------------------
            var multiplicador = 2;
            Metodo3(valor * multiplicador);
        }

        public void Metodo3(int dados)
        {
            //_________Metodo3________
            //| dados                 |
            //|                       |
            //|                       |
            //|                       |
            //-------------------------
            //_________Metodo2________
            //| valor                 |
            //| multiplicador         |
            //|                       |
            //|                       |
            //-------------------------
            //_________Metodo1________
            //|                       |
            //|                       |
            //|                       |
            //|                       |
            //-------------------------
            Console.WriteLine("O dobro do valor é "+dados.ToString());
        }

    }
}
