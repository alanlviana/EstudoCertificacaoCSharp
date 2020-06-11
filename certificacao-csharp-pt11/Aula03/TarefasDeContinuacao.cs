using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_pt11.Aula03
{
    class TarefasDeContinuacao : IExecutavel
    {
        public void Executar()
        {
            var taskOla = Task.Run(() => Ola());

            taskOla.ContinueWith((tarefaAnterior) => Mundo(),TaskContinuationOptions.NotOnFaulted);
            taskOla.ContinueWith((tarefaAnterior) => Erro(tarefaAnterior.Exception),TaskContinuationOptions.OnlyOnFaulted);



        }

        private void Erro(Exception e)
        {
            Console.WriteLine("Erro:"+e.Message);
        }

        private static void Mundo()
        {
            Console.WriteLine("Mundo");
        }

        private static void Ola()
        {
            Console.WriteLine("Olá");
            throw new ApplicationException("Falha ao dizer olá!");

        }
    }
}
