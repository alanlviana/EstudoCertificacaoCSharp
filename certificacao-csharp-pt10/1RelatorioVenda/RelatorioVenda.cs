#define RELATORIO_COMPLETO
using Curso.Arquitetura.Menu;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace certificacao_csharp_pt10._1RelatorioVenda
{
    class RelatorioVenda : IExecutavel
    {
        public void Executar()
        {
            new Relatorio().Imprimir();
        }
    }

    class Relatorio
    {
        public string Nome { get; set; }

        private IList<Venda> Vendas { get; }
        public Relatorio()
        {
            Vendas = JsonConvert.DeserializeObject<List<Venda>>(File.ReadAllText("Vendas.json"));
        }

        public void Imprimir()
        {
            //#if RELATORIO_REDUZIDO
            //            RelatorioReduzido();
            //#else
            //            RelatorioCompleto();
            //#endif

            Console.WriteLine(Nome);

            RelatorioReduzido();
            RelatorioCompleto();

        }

        [Conditional("RELATORIO_REDUZIDO")]
        private void RelatorioReduzido()
        {

            FormatoResumidoAttribute formatoDetalhado = (FormatoResumidoAttribute)Attribute.GetCustomAttribute(typeof(Venda), typeof(FormatoResumidoAttribute));
            var formato = formatoDetalhado.Formato;

            foreach (var venda in Vendas)
            {
                Console.WriteLine(formato, venda.Preco, venda.TipoPagamento, venda.Cidade, venda.Produto);
            }
        }
        [Conditional("RELATORIO_COMPLETO")]

        private void RelatorioCompleto()
        {
            FormatoDetalhadoAttribute formatoDetalhado = (FormatoDetalhadoAttribute)Attribute.GetCustomAttribute(typeof(Venda), typeof(FormatoDetalhadoAttribute));
            var formato = formatoDetalhado.Formato;

            foreach (var venda in Vendas)
            {
                Console.WriteLine(formato, venda.Preco, venda.TipoPagamento,venda.Cidade, venda.Produto);
            }
        }
    }
}
