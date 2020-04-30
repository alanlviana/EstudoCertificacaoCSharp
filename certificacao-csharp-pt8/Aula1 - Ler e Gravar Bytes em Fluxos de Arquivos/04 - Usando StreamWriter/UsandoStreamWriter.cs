using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Unicode;

namespace certificacao_csharp_pt8.Aula1
{
    class UsandoStreamWriter : IExecutavel
    {
        public void Executar()
        {
            using(var streamWriter = new StreamWriter("ArquivoSaidaStreamWriter.txt")){
                streamWriter.Write("Olá Alura!");
            }
        }
    }
}
