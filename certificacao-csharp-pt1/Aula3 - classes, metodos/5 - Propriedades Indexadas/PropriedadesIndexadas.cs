using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class PropriedadesIndexadas : IAulaItem
    {
        public void Executar()
        {
            var sala = new Sala();
            sala["A01"] =  new ClienteCinema("Arthurito");
            sala["A02"] =  new ClienteCinema("Estocolmo");

            sala.ImprimirReservas();
        }

    }

    class ClienteCinema
    {
        public string NomeCliente { get; }

        public ClienteCinema(string nomeCliente)
        {
            NomeCliente = nomeCliente;
        }

        public override string ToString()
        {
            return NomeCliente;
        }
    }

    class Sala
    {
        private readonly IDictionary<string, ClienteCinema> reservas = new Dictionary<string, ClienteCinema>();

        public ClienteCinema this[string codigoAssento]
        {
            get
            {
                return reservas[codigoAssento];
            }
            set
            {
                reservas[codigoAssento] = value;
            }
        }

        public void ImprimirReservas()
        {
            Console.WriteLine("Assentos Reservados");
            Console.WriteLine("*******************");

            foreach(var reserva in reservas)
            {
                Console.WriteLine($"Assento: {reserva.Key}, Cliente: {reserva.Value}");
            }
        }
    }


}
