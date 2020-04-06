using certificacao_csharp_pt7.Aula1;
using Curso.Arquitetura.Menu;
using System.Collections.Generic;

namespace certificacao_csharp_pt6
{
    class MenuPrincipal : Menu
    {
        protected override IList<MenuItem> GetMenuItems()
        {
            return new List<MenuItem> {
                new MenuItem("Introdução a Eventos", typeof(IntroducaoEventos))
            }; 
        }
    }
}
