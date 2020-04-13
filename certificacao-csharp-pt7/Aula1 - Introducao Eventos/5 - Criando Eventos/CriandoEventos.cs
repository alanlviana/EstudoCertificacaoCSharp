using Curso.Arquitetura.Menu;
using System;
using System.Runtime.CompilerServices;

namespace certificacao_csharp_pt7.Aula1
{
    class CriandoEventos : IExecutavel
    {
        public void Executar()
        {
            var campainha = new Campainha();

            campainha.OnCampainhaTocou += (s, a) =>
            {
                Console.WriteLine("Campainha tocada! (1)");
            };


            campainha.OnCampainhaTocou += (s, a) =>
            {
                Console.WriteLine($"Campainha tocada! (2) Apartamento:{a.Apartamento}");
            };

            campainha.Tocar("101");
        }

        private class Campainha
        {
            public event EventHandler<CampainhaTocouEventArgs> OnCampainhaTocou;

            public void Tocar(string apartamento)
            {
                this.OnCampainhaTocou?.Invoke(this, new CampainhaTocouEventArgs(apartamento));
            }
        }

        private class CampainhaTocouEventArgs : EventArgs
        {
            public string Apartamento { get;  }

            public CampainhaTocouEventArgs(string apartamento)
            {
                this.Apartamento = apartamento;
            }
        }



    }
}
