using certificacao_csharp_pt9_console._01___Debugando;
using Curso.Arquitetura.Menu;
using System.Collections.Generic;

namespace certificacao_csharp_pt9_console
{
    class MenuPrincipal : Menu
    {
        protected override IList<MenuItem> GetMenuItems()
        {
            return new List<MenuItem> {
                new MenuItem("VersaoAssembly", typeof(VersaoAssembly)),
                new MenuItem("NomeForteAssembly", typeof(NomeForteAssembly)),
                new MenuItem("MedindoTempoExecucao", typeof(MedindoTempoExecucao)),
                new MenuItem("MonitorandoExecucao", typeof(MonitorandoExecucao)),

                

            }; 
        }
    }
}
