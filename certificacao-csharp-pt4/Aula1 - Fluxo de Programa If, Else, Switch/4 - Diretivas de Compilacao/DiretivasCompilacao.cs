using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt4.Item4
{
    class DiretivasCompilacao : IExecutavel
    {
        public void Executar()
        {
            var emprestimo = new Emprestimo("XPTO02");
            emprestimo.CalcularJuros(6000, 2);
            emprestimo.CalcularJuros(8000, 7);

            emprestimo.Finalizar();

        }

    }
}