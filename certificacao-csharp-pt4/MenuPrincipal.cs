using certificacao_csharp_pt4.Item4;
using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt4
{
    class MenuPrincipal : Menu
    {
        protected override IList<MenuItem> GetMenuItems()
        {
            return new List<MenuItem> { 
                new MenuItem("If e Else", typeof(IfElse)),
                new MenuItem("Combinando Expressões Booleanas", typeof(CombinandoExpressoesBooleanas)),
                new MenuItem("Usando Switch", typeof(UsandoSwitch)),
                new MenuItem("Diretivas de Compilação", typeof(DiretivasCompilacao)),
                new MenuItem("While-Do", typeof(WhileDo)),
            };
        }
    }
}
