
using certificacao_csharp_pt8.Aula1;
using Curso.Arquitetura.Menu;
using System.Collections.Generic;

namespace certificacao_csharp_pt8
{
    class MenuPrincipal : Menu
    {
        protected override IList<MenuItem> GetMenuItems()
        {
            return new List<MenuItem> {
                new MenuItem("A classe file stream", typeof(ClasseFileStream)),
                
            }; 
        }
    }
}
