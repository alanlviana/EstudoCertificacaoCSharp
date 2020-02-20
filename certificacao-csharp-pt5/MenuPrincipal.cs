using certificacao_csharp_pt5.aula2;
using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt5
{
    class MenuPrincipal : Menu
    {
        protected override IList<MenuItem> GetMenuItems()
        {
            return new List<MenuItem> { 
                new MenuItem("Tipos de Valor", typeof(TiposDeValor)),
                new MenuItem("Tipos de Referência", typeof(TiposDeReferencia)),
                new MenuItem("Finalizador", typeof(Finalizador)),
                new MenuItem("Disposable", typeof(PadraoDisposable)),

                
            };
        }
    }
}
