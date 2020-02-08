using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt3
{
    class ModificadoresDeVisibilidade : IExecutavel
    {
        public void Executar()
        {
            Banco banco = new Banco();
        }

    }

    class Banco
    {
        public Banco()
        {
            Conta conta = new Conta();
            conta.Saldo = 1000;
            Console.WriteLine($"Banco diz que conta tem saldo {conta.Saldo}");

        }
    }

    class Conta
    {
        // private = visivel somente dentro da própria classe
        // protected = visivel para a própria classe e classes derivadas
        // internal = visivel para classes externas do mesmo assembly.
        // public = visivel para todas as classes
        // Removendo o set = o atributo passa a ser readonly, sendo assim só poder ser alterado no construtor
        public decimal Saldo { get; set; }

        public Conta()
        {
            this.Saldo = 1000;
            Console.WriteLine($"Saldo: {this.Saldo}");
        }

        void Sacar(decimal saque)
        {
            this.Saldo -= saque;
        }
    }

    class ContaCorrente : Conta
    {
        public ContaCorrente()
        {
            this.Saldo = 1000;
            Console.WriteLine($"Saldo = {this.Saldo}");
        }
    }


}
