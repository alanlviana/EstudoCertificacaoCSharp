using certificacao_csharp_pt6.Aula1;
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
                
            };
        }
    }
}
