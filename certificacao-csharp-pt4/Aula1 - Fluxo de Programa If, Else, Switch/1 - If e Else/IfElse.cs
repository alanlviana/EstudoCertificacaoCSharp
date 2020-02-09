using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt4
{
    class IfElse : IExecutavel
    {
        public void Executar()
        {
            ContaBancaria conta = new ContaBancaria(100);
            conta.SacarDinheiro(50);
            conta.SacarDinheiro(100);
        }

    }

    class ContaBancaria
    {
        private decimal Saldo { get; set; }

        public ContaBancaria(int saldo)
        {
            this.Saldo = saldo;
            ImprimirSaldo();
        }

        public RetornoOperacao SacarDinheiro(decimal valor)
        {
            Console.WriteLine($"Iniciando saque de {valor:C}");

            // Cláusula de Guarda
            if (!PossuiSaldoSuficiente(valor))
            {
                ImprimirAviso("Saldo insuficiente.");
                return RetornoOperacao.SaldoInsuficiente;
            } 

            Debitar(valor);
            EntregarNotas(valor);
            ImprimirComprovante(valor);
            ImprimirSaldo();

            return RetornoOperacao.OperacaoRealizada;
        }

        private void ImprimirAviso(string mensagem)
        {
            Console.WriteLine(mensagem);
        }

        private bool PossuiSaldoSuficiente(decimal valor)
        {
            return Saldo > valor;
        }

        private void Debitar(decimal valor)
        {
            Saldo -= valor;
        }

        private void EntregarNotas(decimal valor)
        {
            Console.WriteLine($"Entregando o valor de {valor:C}");
        }

        private void ImprimirComprovante(decimal valor)
        {
            Console.WriteLine($"Imprimindo comprovante para com valor {valor:C}");
        }

        private void ImprimirSaldo()
        {
            Console.WriteLine($"Saldo: {Saldo:C}");
        }
    }

    enum RetornoOperacao
    {
        OperacaoRealizada,
        SaldoInsuficiente,
        CaixaSemNotas,
        FalhaComunicacaoServidor
    }
}
