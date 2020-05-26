using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt10._1RelatorioVenda
{
    class TestarAtributo : IExecutavel
    {
        public void Executar()
        {
            var vendaPossuiAtributoSerializable = Attribute.IsDefined(typeof(Venda), typeof(SerializableAttribute));
            if (vendaPossuiAtributoSerializable)
            {
                Console.WriteLine("A classe venda DEFINE o atributo Serializable.");
            }
            else
            {
                Console.WriteLine("A classe venda NÃO DEFINE o atributo Serializable.");
            }
        }
    }
}
