using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class ParametrosNomeados : IAulaItem
    {
        public void Executar()
        {
            // Forma mais convencional para realizar a chamada de um método
            // Ordem correta dos argumentos e tipos influencia no binding
            ImprimirDetalhesDoPedido("Zé das Couves", 128, "Couve");

            // Parametros nomeados podem ser informados em qualquer ordem
            ImprimirDetalhesDoPedido(numeroPedido: 128, nomeProduto: "Couve", vendedor:"Zé das Couves");
            ImprimirDetalhesDoPedido(nomeProduto: "Couve", vendedor:"Zé das Couves", numeroPedido: 128);

            // Parametros nomeados podem ser usados com parametros posicionais
            // Mas a ordem vai influenciar no binding\
            ImprimirDetalhesDoPedido("Zé das Couves", 128, nomeProduto:"Couve");

        }

        void ImprimirDetalhesDoPedido(string vendedor, int numeroPedido, string nomeProduto)
        {
            if (string.IsNullOrEmpty(vendedor)) {
                throw new ArgumentNullException("o parametro vendedor não pode ser nulo ou vazio");
            }

            Console.WriteLine($"Vendedor: {vendedor}, Numero do Pedido:{numeroPedido}, Nome do Produto: {nomeProduto}");
        }
    }


}
