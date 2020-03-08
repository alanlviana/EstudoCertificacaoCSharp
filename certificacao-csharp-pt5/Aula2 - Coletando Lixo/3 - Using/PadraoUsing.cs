using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace certificacao_csharp_pt5.aula2
{
    class PadraoUsing : IExecutavel
    {
        public void Executar()
        {
            using (var mensageiro = new MensageiroNotepad())
            {
                mensageiro.EnviarMensagem("Hello World!");
            }

            //using (var s = new string('x', 10)) 'string': type used in a using statement must be implicitly convertible to 'System.IDisponsable' or implement a suitable 'Disponse' method.
            //{
            //
            //}
        }
    }

}
