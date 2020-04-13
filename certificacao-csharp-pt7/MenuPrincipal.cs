using certificacao_csharp_pt7.Aula1;
using certificacao_csharp_pt7.Aula2;
using certificacao_csharp_pt7.Aula3;
using certificacao_csharp_pt7.Aula5;
using Curso.Arquitetura.Menu;
using System.Collections.Generic;

namespace certificacao_csharp_pt6
{
    class MenuPrincipal : Menu
    {
        protected override IList<MenuItem> GetMenuItems()
        {
            return new List<MenuItem> {
                new MenuItem("Introdução a Action", typeof(IntroducaoAction)),
                new MenuItem("Criando Eventos", typeof(CriandoEventos)),
                new MenuItem("Manipuladores de Eventos", typeof(ManipuladoresEventos)),
                new MenuItem("Criando Delegates", typeof(CriandoDelegates)),
                new MenuItem("Criando Delegates", typeof(CriandoDelegates)),
                new MenuItem("Relatório de Filmes", typeof(RelatorioFilmes)),
                
            }; 
        }
    }
}
