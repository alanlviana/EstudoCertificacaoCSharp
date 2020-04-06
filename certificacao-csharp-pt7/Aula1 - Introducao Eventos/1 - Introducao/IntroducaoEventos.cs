using Curso.Arquitetura.Menu;
using System;

namespace certificacao_csharp_pt7.Aula1
{
    class IntroducaoEventos : IExecutavel
    {
        public void Executar()
        {
            var campainha = new Campainha();

            campainha.OnCampainhaTocou = () =>
            {
                Console.WriteLine("Campainha tocada!");
            };

            campainha.Tocar();
        }

        private class Campainha
        {
            public Action OnCampainhaTocou { get; set; }

            public void Tocar()
            {
                this.OnCampainhaTocou?.Invoke();
            }
        }

    }
}
