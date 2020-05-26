using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt10._1RelatorioVenda
{
    [FormatoResumido("{0,20:C} {1,20}")]
    [FormatoDetalhado("{0,20:C} {1,20} {2,20} {3,20}")]
    [Serializable]
    class Venda
    {
        public string Data { get; set; }
        public string Produto { get; set; }
        public double Preco { get; set; }
        public string TipoPagamento { get; set; }
        [NonSerialized]
        public string Nome;
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string DataCriacao { get; set; }
        public string UltimoLogin { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class FormatoResumidoAttribute : Attribute
    {
        public string Formato { get; }

        public FormatoResumidoAttribute(string formato)
        {
            this.Formato = formato;
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class FormatoDetalhadoAttribute : Attribute
    {
        public string Formato { get; }

        public FormatoDetalhadoAttribute(string formato)
        {
            this.Formato = formato;
        }
    }
}
