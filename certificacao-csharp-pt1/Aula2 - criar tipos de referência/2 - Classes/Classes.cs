using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class Classes : IAulaItem
    {
        public void Executar()
        {
            ClassePosicaoGPS posicao1 = new ClassePosicaoGPS()
            {
                Latitude = 13.78,
                Longitude = 29.51
            };
            Console.WriteLine(posicao1);
            Console.WriteLine();
            PosicaoGPSComLeitura posicao2 = new PosicaoGPSComLeitura(13.78, 29.51, DateTime.Now);

            Console.WriteLine(posicao2);

        }
    }

    class ClassePosicaoGPS
    {
        public double Latitude;
        public double Longitude;
        public ClassePosicaoGPS() { }

        public ClassePosicaoGPS(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override string ToString()
        {
            return $"{{Latitude: {Latitude}, Longitude: {Longitude}}}";
        }
    }

    class PosicaoGPSComLeitura: ClassePosicaoGPS
    {
        private readonly DateTime dataLeitura;
        public override string ToString()
        {
            return $"{{Latitude: {Latitude}, Longitude: {Longitude}, DataLeitura: {dataLeitura}}}";
        }
        public PosicaoGPSComLeitura(double latitude, double longitude, DateTime dataLeitura) : base(latitude, longitude)
        {
            this.dataLeitura = dataLeitura;
        }
    }

}
