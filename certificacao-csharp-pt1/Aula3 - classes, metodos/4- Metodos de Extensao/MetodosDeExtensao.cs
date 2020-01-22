using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class MetodosDeExtensao : IAulaItem
    {
        public void Executar()
        {
            Impressora impressaora = new Impressora("Esse é o \r\no meu documento!");
            impressaora.ImprimirDocumento();
            impressaora.ImprimirDocumentoHTML();
        }

    }

    static class ImpressoraExtensions {
        public static void ImprimirDocumentoHTML(this Impressora impressora)
        {
            Console.WriteLine($"<html><body>{impressora.Documento}</body></html>");
        }
    }



    class Impressora
    {
        public readonly string Documento;

        public Impressora(string documento)
        {
            this.Documento = documento;
        }

        public void ImprimirDocumento()
        {
            Console.WriteLine(Documento);
        }
        //public void ImprimirDocumentoHTML()
        //{
        //    Console.WriteLine($"<html><body>{impressao}</body></html>");
        //}
    }


}
