using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Xml.Schema;

namespace certificacao_csharp_pt7.Aula2
{
    class ManipuladoresEventos : IExecutavel
    {
        public void Executar()
        {
            var campainha = new Campainha();

            campainha.OnCampainhaTocou += Metodo1;
            campainha.OnCampainhaTocou += Metodo2;
            try
            {
                campainha.Tocar("101");
            }
            catch (AggregateException e)
            {
                foreach(var exception in e.InnerExceptions)
                {
                    Console.WriteLine(exception.Message);
                }
            }catch(Exception e)
            {

            }
        }

        private void Metodo1(object sender, CampainhaTocouEventArgs e)
        {
            Console.WriteLine($"Campainha tocada! (1) Apartamento:{e.Apartamento}");
            throw new Exception("Falha no método 1");
        }

        private void Metodo2(object sender, CampainhaTocouEventArgs e)
        {
            Console.WriteLine($"Campainha tocada! (2) Apartamento:{e.Apartamento}");
            throw new Exception("Falha no método 2");
        }

        private class Campainha
        {
            public event EventHandler<CampainhaTocouEventArgs> OnCampainhaTocou;

            public void Tocar(string apartamento)
            {

                var listaExceptions = new List<Exception>();
                foreach(var handle in OnCampainhaTocou.GetInvocationList())
                {

                    try
                    {
                        handle.DynamicInvoke(this, new CampainhaTocouEventArgs(apartamento));
                    }
                    catch(Exception e)
                    {
                        listaExceptions.Add(e.InnerException);
                    }

                }
                if (listaExceptions.Count > 0)
                {
                    throw new AggregateException(listaExceptions);
                }
            }
        }

        private class CampainhaTocouEventArgs : EventArgs
        {
            public string Apartamento { get; }

            public CampainhaTocouEventArgs(string apartamento)
            {
                this.Apartamento = apartamento;
            }
        }



    }
}
