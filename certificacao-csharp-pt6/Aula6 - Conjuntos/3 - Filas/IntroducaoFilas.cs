using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;

namespace certificacao_csharp_pt6.Aula6
{
    class IntroducaoFilas : IExecutavel
    {
        public void Executar()
        {
            var pedagio = new Pedagio();
            pedagio.EnfileirarVeiculo("Van");
            pedagio.EnfileirarVeiculo("Kombi");
            pedagio.EnfileirarVeiculo("Guincho");
            pedagio.EnfileirarVeiculo("Pickup");

            pedagio.DesenfileirarVeiculo();
            pedagio.DesenfileirarVeiculo();
            pedagio.DesenfileirarVeiculo();
            pedagio.DesenfileirarVeiculo();
            pedagio.DesenfileirarVeiculo();
            // pedagio.DesenfileirarVeiculo(); System.InvalidOperationException: Queue empty.


        }


        private class Pedagio
        {
            public Queue<string> Veiculos { get; } = new Queue<string>();

            public void EnfileirarVeiculo(string veiculo)
            {
                Console.WriteLine();
                Veiculos.Enqueue(veiculo);
                Console.WriteLine("Entrou na fila: " + veiculo);

                Console.WriteLine();
                VeiculosNaFila();
            }

            private void VeiculosNaFila()
            {
                Console.WriteLine("Veiculos na fila:");

                foreach (var veiculoFila in Veiculos)
                {
                    Console.WriteLine(veiculoFila);
                }
            }

            public void DesenfileirarVeiculo()
            {
                if (Veiculos.Count == 0)
                {
                    Console.WriteLine("Não existem veiculos na fila.");
                    return;
                }
                Console.WriteLine();
                if (Veiculos.TryPeek(out string chamandoVeiculo))
                {
                    Console.WriteLine("Chamando: "+ chamandoVeiculo);
                }


                var veiculo = Veiculos.Dequeue();
                Console.WriteLine("Saiu da fila: "+veiculo);

                if (Veiculos.TryPeek(out string proximoVeiculo))
                {
                    Console.WriteLine("Próximo veiculo: " + proximoVeiculo);
                }

                Console.WriteLine();
                VeiculosNaFila();
            }
        }
        
    }


}
