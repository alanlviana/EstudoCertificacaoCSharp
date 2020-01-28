using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class MetodosSubstituidos : IAulaItem
    {
        public void Executar()
        {
            Console.WriteLine("Animal gato = new Gato()");
            Animal gato = new Gato() { Nome = "Bichano" };
            gato.Andar();
            gato.Beber();
            gato.Comer();
            Console.WriteLine();

            Console.WriteLine("Gato gata = new Gato()");
            Gato gata = new Gato() { Nome = "Bichana" };
            gata.Andar();
            gata.Beber();
            gata.Comer();
            Console.WriteLine();

            Console.WriteLine("var gatoVariavel = new Gato()");
            var gatoVariavel = new Gato() { Nome = "Variavel" };
            gatoVariavel.Andar();
            gatoVariavel.Beber();
            gatoVariavel.Comer();
            Console.WriteLine();

        }

    }

    class Animal
    {
        public string Nome { get; set; }

        public virtual void Beber()
        {
            Console.WriteLine("Animal.Beber()");
        }

        public void Comer()
        {
            Console.WriteLine("Animal.Comer()");
        }

        public void Andar()
        {
            Console.WriteLine("Animal.Andar()");
        }
    }


    class Gato: Animal
    {
        public string Nome { get; set; }

        public override void Beber()
        {
            Console.WriteLine("override Gato.Beber()");
        }

        public new void Comer()
        {
            Console.WriteLine("Gato.Comer()");
        }

        public new void Andar()
        {
            Console.WriteLine("Gato.Andar()");
        }
    }


}
