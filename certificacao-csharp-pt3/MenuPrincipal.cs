using certificacao_csharp_pt3.Aula3;
using certificacao_csharp_pt3.Aula4;
using certificacao_csharp_pt3.Aula5;
using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt3
{
    class MenuPrincipal : Menu
    {
        protected override IList<MenuItem> GetMenuItems()
        {
            return new List<MenuItem>
            {
                // Curso 3
                new MenuItem("Encapsulamento", typeof(Encapsulamento)),
                new MenuItem("Modificadores de Visibilidade", typeof(ModificadoresDeVisibilidade)),
                new MenuItem("Projetando Interfaces", typeof(ProjetandoInterfaces)),
                new MenuItem("Interfaces Explicitas", typeof(InterfacesExplicitas)),
                new MenuItem("Classe Base", typeof(ClasseBase)),
                new MenuItem("Equals", typeof(Equals)),
            };
        }
    }
}
