using certificacao_csharp_pt10._1RelatorioVenda;
using certificacao_csharp_pt10._2GeracaoCodigo;
using certificacao_csharp_pt10._3TiposSystemReflection;
using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt10
{
    class MenuPrincipal : Menu
    {
        protected override IList<MenuItem> GetMenuItems()
        {
            return new List<MenuItem>
            {
                new MenuItem("RelatorioVendas1", typeof(RelatorioVenda)),
                new MenuItem("TestarAtributo", typeof(TestarAtributo)),
                new MenuItem("Acessando Metodos com Reflection", typeof(AcessandoMetodoReflection)),
                new MenuItem("Gerar código em tempo de execução", typeof(GeracaoCodigo)),
                new MenuItem("Gerar Arvore de Expressão LINQ", typeof(ArvoreExpressaoLinq)),
                new MenuItem("Outros métodos do System.Reflection", typeof(TiposSystemReflection)),
                
            };
        }
    }
}


