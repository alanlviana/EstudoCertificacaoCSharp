using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt3
{
    class ProjetandoInterfaces : IExecutavel
    {
        public void Executar()
        {

            List<IEletrodomestico> eletrodomesticos = new List<IEletrodomestico>();
            eletrodomesticos.Add(new Televisao());
            eletrodomesticos.Add(new Abajur());
            eletrodomesticos.Add(new Lanterna());
            eletrodomesticos.Add(new Radio());

            foreach (var eletro in eletrodomesticos)
            {
                var nomeEletro = eletro.GetType().Name;
                Console.WriteLine("Monitorando eventos em "+nomeEletro);
                eletro.Ligou += TratarLigar;
                eletro.Desligou += TratarDesligar;
                eletro.Ligar();
                eletro.Desligar();
                Console.WriteLine("Fim do tratamento do "+nomeEletro);
            }

        }

        private void TratarLigar(object sender, EventArgs args)
        {
            Console.WriteLine($"{sender.GetType().Name} ligada.");
        }
        private void TratarDesligar(object sender, EventArgs args)
        {
            Console.WriteLine($"{sender.GetType().Name} desligada.");
        }

    }

    interface IEletrodomestico
    {
        event EventHandler Ligou;
        event EventHandler Desligou;

        void Ligar();
        void Desligar();
    }

    interface IIluminacao
    {
        double PotenciaDaLampada { get; set; }
    }

    class Televisao : IEletrodomestico
    {
        public event EventHandler Ligou;
        public event EventHandler Desligou;

        public void Desligar()
        {
            Desligou.Invoke(this, EventArgs.Empty);
        }

        public void Ligar()
        {
            Ligou.Invoke(this, EventArgs.Empty);
        }
    }
    class Abajur : IEletrodomestico, IIluminacao
    {
        public double PotenciaDaLampada { get; set; }

        public event EventHandler Ligou;
        public event EventHandler Desligou;

        public void Desligar()
        {
            Desligou.Invoke(this, EventArgs.Empty);
        }

        public void Ligar()
        {
            Ligou.Invoke(this, EventArgs.Empty);
        }
    }
    class Lanterna : IEletrodomestico, IIluminacao
    {
        public double PotenciaDaLampada { get ; set; }

        public event EventHandler Ligou;
        public event EventHandler Desligou;

        public void Desligar()
        {
            Desligou.Invoke(this, EventArgs.Empty);
        }

        public void Ligar()
        {
            Ligou.Invoke(this, EventArgs.Empty);
        }
    }

    class Radio : IEletrodomestico
    {
        public event EventHandler Ligou;
        public event EventHandler Desligou;

        public void Desligar()
        {
            Desligou.Invoke(this, EventArgs.Empty);
        }

        public void Ligar()
        {
            Ligou.Invoke(this, EventArgs.Empty);
        }
    }

}
