using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt5.aula4
{
    class StringBuilderExemplo : IExecutavel
    {
        public void Executar()
        {
            string minuscula = "";
            String maiuscula = "";

            var materias = new StringBuilder();

            materias.Append("Portugues");
            Console.WriteLine(materias);

            materias.Append(", Matematica");

            Console.WriteLine(materias);
            materias.Append(", Geografia");

            Console.WriteLine(materias);

            Console.ReadKey();
        }


    }
}
