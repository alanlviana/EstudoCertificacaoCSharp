using ConsoleTables;
using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace certificacao_csharp_pt11.Aula03
{
    class AguardandoFimVariasTarefas : IExecutavel
    {
        public void Executar()
        {
            var tarefas = new Task[10];
            var corredores = new Corredor[10];
            var quantidadeThread = Process.GetCurrentProcess().Threads.Count;
            Console.WriteLine($"Quantidade de threads = {quantidadeThread}");

            for(int i= 0; i < 10; i++)
            {
                int numeroCorredor = i;
                var corredor = new Corredor(numeroCorredor);
                corredores[i] = corredor;
                tarefas[i] =  Task.Run(() => corredor.Correr());
            }

            Task.WaitAll(tarefas);

            quantidadeThread = Process.GetCurrentProcess().Threads.Count;
            Console.WriteLine($"Quantidade de threads = {quantidadeThread}");

            Console.WriteLine("Ranking de corredores");
            ConsoleTable table = new ConsoleTable("#", "Hora Chegada");
            foreach(var corredor in corredores.OrderBy(c => c.HoraChegada))
            {
                table.AddRow(corredor.NumeroCorredor, corredor.HoraChegada);
            }
            table.Write();
        }
    }

    public class Corredor
    {
        public Corredor(int numeroCorredor)
        {
            NumeroCorredor = numeroCorredor;
        }

        public void Correr()
        {
            Console.WriteLine($"Corredor {NumeroCorredor} iniciou.");
            var tempo = new Random().Next(500, 1500);
            Thread.Sleep(tempo);
            Console.WriteLine($"Corredor {NumeroCorredor} finalizou.");
            HoraChegada = DateTime.Now;
        }

        public int NumeroCorredor { get; }
        public DateTime HoraChegada { get; private set; }
    }
}
