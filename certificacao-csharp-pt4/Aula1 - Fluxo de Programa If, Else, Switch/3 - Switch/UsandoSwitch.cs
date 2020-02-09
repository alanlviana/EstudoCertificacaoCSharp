using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt4
{
    class UsandoSwitch : IExecutavel
    {
        public void Executar()
        {
            var caixaEletronico = new CaixaEletronico();
            RetornoOperacao retorno = caixaEletronico.SacarDinheiro(299.99m);

            switch (retorno){
                case RetornoOperacao.OperacaoRealizada:
                    Console.WriteLine("Operacao realizada com sucesso!");
                    break;
                case RetornoOperacao.CaixaSemNotas:
                    Console.WriteLine("Caixa Eletrônico sem notas.");
                    break;
                case RetornoOperacao.FalhaComunicacaoServidor:
                    Console.WriteLine("Falha na comunicação com servidor.");
                    break;
                case RetornoOperacao.SaldoInsuficiente:
                    Console.WriteLine("Saldo insuficiente");
                    break;
                default:
                    Console.WriteLine("Retorno desconhecido.");
                    break;
            }
        }

    }

    class CaixaEletronico
    {

        private ContaBancaria conta = new ContaBancaria(400);
        public RetornoOperacao SacarDinheiro(decimal valor)
        {
            return conta.SacarDinheiro(valor);
        }
    }



}
