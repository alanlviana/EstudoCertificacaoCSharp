using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt10._3TiposSystemReflection.Modelo
{
    class ItemCarrinho
    {
        public ItemCarrinho(string id, string produtoId, string produtoNome, string precoUnitario, string quantidade
            )
        {
            Id = id;
            ProdutoId = produtoId;
            ProdutoNome = produtoNome;
            PrecoUnitario = precoUnitario;
            Quantidade = quantidade;
        }

        public string Id { get; set; }
        public string ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public string PrecoUnitario { get; set; }
        public string Quantidade { get; set; }

    }
}
