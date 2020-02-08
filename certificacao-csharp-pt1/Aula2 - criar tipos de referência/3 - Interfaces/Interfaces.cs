using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    public class Interfaces : IExecutavel
    {
        public void Executar()
        {
            Console.WriteLine("Aula de interfaces!");

            IEletrodomestico eletro = new Televisao();
            eletro.Ligar();
            eletro.Desligar();

            eletro = new Abajur();
            eletro.Ligar();
            eletro.Desligar();

            eletro = new Radio();
            eletro.Ligar();
            eletro.Desligar();

            eletro = new Lanterna();
            eletro.Ligar();
            eletro.Desligar();
        }
    }

    interface IEletrodomestico
    {
        void Ligar();
        void Desligar();
    }

    interface IIluminacao
    {
        double PotenciaDaLampada { get; set; }
    }

    class Televisao : IEletrodomestico
    {
        public void Desligar()
        {
            Console.WriteLine($"Desligando {this.GetType().Name}");
        }

        public void Ligar()
        {
            Console.WriteLine($"Ligando {this.GetType().Name}");
        }
    }

    class Abajur : IEletrodomestico, IIluminacao
    {
        public double PotenciaDaLampada { get; set ; }

        public void Desligar()
        {
            Console.WriteLine($"Desligando {this.GetType().Name}");
        }

        public void Ligar()
        {
            Console.WriteLine($"Ligando {this.GetType().Name}");
        }
    }

    class Lanterna : IEletrodomestico, IIluminacao 
    {
        public double PotenciaDaLampada { get; set; }

        public void Desligar()
        {
            Console.WriteLine($"Desligando {this.GetType().Name}");
        }

        public void Ligar()
        {
            Console.WriteLine($"Ligando {this.GetType().Name}");
        }
    }

    class Radio : IEletrodomestico
    {
        public void Desligar()
        {
            Console.WriteLine($"Desligando {this.GetType().Name}");
        }

        public void Ligar()
        {
            Console.WriteLine($"Ligando {this.GetType().Name}");
        }
    }

}
