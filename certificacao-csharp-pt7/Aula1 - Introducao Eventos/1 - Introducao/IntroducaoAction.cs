using Curso.Arquitetura.Menu;
using System;

namespace certificacao_csharp_pt7.Aula1
{
    class IntroducaoAction : IExecutavel
    {
        public void Executar()
        {
            var campainha = new Campainha();

            campainha.OnCampainhaTocou += () =>
            {
                Console.WriteLine("Campainha tocada! (1)");
            };


            campainha.OnCampainhaTocou += () =>
            {
                Console.WriteLine("Campainha tocada! (2)");
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
