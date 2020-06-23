using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt12.Aula03
{
    class IntegridadeDeDados : IExecutavel
    {
        public void Executar()
        {
            

            ContaCorrente contaCorrente = new ContaCorrente("05201-2", "José", 200);
            Console.WriteLine($"O saldo do cliente é: {contaCorrente.Saldo} ");



            try
            {
                Console.WriteLine("Tenta sacar 50 reais.");

                contaCorrente.Sacar(50);
                Console.WriteLine("Saque de 50 reais realizado.");
                Console.WriteLine($"O saldo do cliente é: {contaCorrente.Saldo:C} ");
                Console.WriteLine("Tenta sacar 500 reais.");
                contaCorrente.Sacar(500);
                Console.WriteLine("Saque de 500 reais realizado.");
            }catch(Exception e)
            {
                Console.WriteLine("Falha ao realizar um dos saques: "+e.Message);
            }


            Console.WriteLine($"O saldo do cliente é: {contaCorrente.Saldo:C} ");
        }
    }


    public class ContaCorrente
    {
        public ContaCorrente(string numeroConta, string titular, decimal saldo)
        {
            NumeroConta = numeroConta;
            Titular = titular;
            Saldo = saldo;
        }

        public string NumeroConta { get; set; }
        public string Titular { get; set; }
        public decimal Saldo { get; private set; }

        public void Sacar(decimal valorSaque)
        {
            if (valorSaque > Saldo)
            {
                throw new ArgumentException("O valor é maior que o saldo da conta.", "valorSaque");
            }

            Saldo -= valorSaque;
        }
    }
}
