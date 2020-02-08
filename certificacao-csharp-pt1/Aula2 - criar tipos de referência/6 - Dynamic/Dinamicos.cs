using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    public class Dinamicos : IExecutavel
    {
        public void Executar()
        {
            object objeto = 1;
            //objeto = objeto + 3;
            dynamic dinamico = 1;
            dinamico = dinamico + 3;
            Console.WriteLine($"dinamico = {dinamico}");

            //dinamico.teste(); `int` não contém uma definição para `teste`
        }
    }

}

