using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class OperadoresISeAS : IExecutavel
    {
        public void Executar()
        {
            Animal animal = new Animal();
            Gato gato = new Gato();
            Cliente cliente = new Cliente("Zé das Flores", 35);

            Alimentar(animal);
            Alimentar(gato);
            Alimentar(cliente);


        }

        public void Alimentar(object obj)
        {
            
  
            if (obj is Animal objAnimal)
            {
                objAnimal.Comer();
                objAnimal.Beber();
                return;
            }

            Console.WriteLine("obj não é um animal.");
            
            
            
        }
    }

}