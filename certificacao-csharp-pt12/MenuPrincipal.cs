
using certificacao_csharp_pt12.Aula01;
using certificacao_csharp_pt12.Aula02;
using certificacao_csharp_pt12.Aula03;
using certificacao_csharp_pt12.Aula04;
using certificacao_csharp_pt12.Aula05;
using certificacao_csharp_pt12.Aula07;
using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt12
{
    class MenuPrincipal : Menu
    {
        protected override IList<MenuItem> GetMenuItems()
        {
            return new List<MenuItem>
            {
                new MenuItem("Formato Json", typeof(FormatoJson)),
                new MenuItem("Formato XML", typeof(FormatoXML)),
                new MenuItem("Validando JSON", typeof(ValidandoJSON)),
                new MenuItem("Escolhendo Tipo Colecao - Parte 1", typeof(EscolhendoTipoColecaoParte1)),
                new MenuItem("Escolhendo Tipo Colecao - Parte 2", typeof(EscolhendoTipoColecaoParte2)),
                new MenuItem("Integridade dos dados", typeof(IntegridadeDeDados)),
                new MenuItem("Validando entrada com expressão regular", typeof(ValidandoEntradaComExpressaoRegular)),
                new MenuItem("Extraindo correspondências com expressão regular", typeof(ValidarURLComExpressaoRegular)),
                new MenuItem("Validando com funções internas", typeof(ValidandoComFuncoesInternas)),
                new MenuItem("Escolhendo algoritmo de criptografia - Simetrica(AES)", typeof(EscolhendoAlgoritmoCriptografia)),
                new MenuItem("Escolhendo algoritmo de criptografia - Assimetria(RSA)", typeof(EscolhendoAlgoritmoCriptografiaAssimetrica)),
                new MenuItem("Assinando e validando mensagems com certificado", typeof(AssinandoMensagem)),
                new MenuItem("Checksum e HashCodes", typeof(CheckSum)),
                
            }; 
        }
    }
}
