using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt10._3TiposSystemReflection.Modelo
{
    class CarrinhoCliente
    {
        public CarrinhoCliente(string clienteId, List<ItemCarrinho> itens)
        {
            ClienteId = clienteId;
            Itens = itens;
        }

        public string ClienteId { get; private set; }
        public List<ItemCarrinho> Itens { get; private set; }


    }
}
