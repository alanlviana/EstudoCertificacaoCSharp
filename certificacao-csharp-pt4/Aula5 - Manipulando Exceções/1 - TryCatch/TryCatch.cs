using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt4.Item5
{
    class TryCatch : IExecutavel
    {
        public void Executar()
        {
            ContaCorrente conta1 = new ContaCorrente(1, 100);
            ContaCorrente conta2 = new ContaCorrente(2, 200);

            Console.WriteLine(conta1);
            Console.WriteLine(conta2);

            ITransferenciaBancaria transferencia = new TransferenciaBancaria();
            transferencia.Efetuar(conta1, conta2, 30);

            Console.WriteLine(conta1);
            Console.WriteLine(conta2);

            try { 
                transferencia.Efetuar(conta1, null, 50);
            }catch (Exception e)
            {
                Console.WriteLine("Operação não efetuada. Tente novamente mais tarde.");
                Console.WriteLine(e.ToString());
            }
            
            
            Console.WriteLine(conta1);
            Console.WriteLine(conta2);

            try
            {
                transferencia.Efetuar(conta1, conta2, -1);
            }
            catch (Exception e)
            {
                Console.WriteLine("Operação não efetuada. Tente novamente mais tarde.");
                Console.WriteLine(e.ToString());

            }


            try
            {
                transferencia.Efetuar(conta1, conta2, 300);
            }
            catch (Exception e)
            {
                Console.WriteLine("Operação não efetuada. Tente novamente mais tarde.");
                Console.WriteLine(e.ToString());

            }



            Console.ReadLine();
        }

    }

    internal class ContaCorrente
    {
        public int Id { get; set; }
        public decimal Saldo { get; private set; }

        public ContaCorrente(int id, int saldo)
        {
            this.Id = id;
            this.Saldo = saldo;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Saldo: {Saldo:C}";
        }

        public void Debitar(decimal valor)
        {
            Saldo -= valor;
        }

        internal void Creditar(decimal valor)
        {
            Saldo += valor;
        }
    }

    interface ITransferenciaBancaria
    {
        void Efetuar(ContaCorrente contaDebito, ContaCorrente contaCredito, decimal valor);
    }

    class TransferenciaBancaria : ITransferenciaBancaria
    {
        public void Efetuar(ContaCorrente contaDebito, ContaCorrente contaCredito, decimal valor)
        {
            if (contaDebito == null)
            {
                throw new ArgumentNullException(nameof(contaDebito));
            }

            if (contaCredito == null)
            {
                throw new ArgumentNullException(nameof(contaCredito));
            }

            if (valor <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(valor), "O valor da transferência deve ser maior que zero.");
            }

            if (contaDebito.Saldo < valor)
            {
                throw new SaldoInsuficienteException();
            }

            contaDebito.Debitar(valor);
            contaCredito.Creditar(valor);

            Console.WriteLine($"Transferência de {valor:C} efetuada de conta {contaDebito.Id} para conta {contaCredito.Id}." );
        }
    }


    [Serializable]
    public class SaldoInsuficienteException : Exception
    {
        public SaldoInsuficienteException() { }
        public SaldoInsuficienteException(string message) : base(message) { }
        public SaldoInsuficienteException(string message, Exception inner) : base(message, inner) { }
        protected SaldoInsuficienteException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public override string Message => "Saldo insuficiente.";
    }
}