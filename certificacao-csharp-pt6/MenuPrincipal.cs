using certificacao_csharp_pt6.Aula1;
using certificacao_csharp_pt6.Aula2;
using certificacao_csharp_pt6.Aula3;
using certificacao_csharp_pt6.Aula4;
using certificacao_csharp_pt6.Aula5;
using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt6
{
    class MenuPrincipal : Menu
    {
        protected override IList<MenuItem> GetMenuItems()
        {
            return new List<MenuItem> {
                new MenuItem("Serializando Objetos", typeof(SerializandoObjetos)),
                new MenuItem("Serializando com Arquivos", typeof(SerializandoArquivos)),
                new MenuItem("Deserializando com Arquivos", typeof(DeserializandoArquivos)),
                new MenuItem("Deserializando com Mapeamento", typeof(DeserializandoComMapeamento)),
                new MenuItem("Serializando com Json", typeof(JavascriptSerializerExemplo)),
                new MenuItem("Deserializando com Json", typeof(DeserializandoComJson)),
                new MenuItem("Deserializando com Json (Mapeamento)", typeof(DeserializandoComJsonMapeamento)),
                new MenuItem("Serializacao Binaria", typeof(SerializacaoBinaria)),
                new MenuItem("Deserialização Binaria", typeof(DeserializacaoBinaria)),
                new MenuItem("Serialização com Contrato", typeof(SerializacaoComContrato)),               
                new MenuItem("Deserialização com Contrato", typeof(DeserializacaoComContrato)),               
                new MenuItem("Serialização Personalizada", typeof(SerializacaoPersonalizada)),               
                new MenuItem("Introducao Arrays", typeof(IntroducaoArrays)),               
                new MenuItem("Acessando elementos de arrays", typeof(AcessandoElementosArray)),
                new MenuItem("Buscando e Redirecionando Array", typeof(BuscandoRedirecionandoArray)),
                new MenuItem("Ordenando, Copiando, Clonando e Limpando Arrays", typeof(OrdenandoCopiandoClonandoLimpandoArray)),
                new MenuItem("Introducao Lista", typeof(IntroducaoLista)),
                new MenuItem("Lista somente leitura", typeof(ListaSomenteLeitura)),
            }; 
        }
    }
}
