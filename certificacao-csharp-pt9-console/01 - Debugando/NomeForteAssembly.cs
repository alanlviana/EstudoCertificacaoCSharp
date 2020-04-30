using certificacao_csharp_pt9_dados;
using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt9_console._01___Debugando
{
    class NomeForteAssembly : IExecutavel
    {

        public void Executar()
        {
            var asmFullname = typeof(NomeForteAssembly).Assembly.FullName.ToString();

            Console.WriteLine(asmFullname);

        }
    }
}
