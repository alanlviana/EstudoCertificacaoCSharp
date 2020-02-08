using System;
using System.Collections.Generic;
using System.Text;

namespace Curso.Arquitetura.Menu
{
    public class MenuItem
    {
        public MenuItem(string titulo, Type tipoClasse)
        {
            Titulo = titulo;
            TipoClasse = tipoClasse;
        }

        public string Titulo { get; set; }
        public Type TipoClasse { get; set; }
    }
}
