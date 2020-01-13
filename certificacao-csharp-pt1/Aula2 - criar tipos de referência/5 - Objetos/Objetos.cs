using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    public class Objetos : IAulaItem
    {
        public void Executar()
        {
            int pontuacao = 10;
            Console.WriteLine($"pontuacao: {pontuacao}");

            Console.WriteLine("Objecto com valor primitivo");
            object meuObjeto = pontuacao;

            Console.WriteLine($"meuObjeto: {meuObjeto}");
            Console.WriteLine($"meuObjeto.GetType(): {meuObjeto.GetType()}");

            Console.WriteLine();
            Console.WriteLine("Objecto com referência de objeto");
            meuObjeto = new Jogador();
            Jogador classRef;
            classRef = (Jogador)meuObjeto; // conversão explicita ou cast
            Console.WriteLine($"classRef.Pontuacao: {classRef.Pontuacao}");
        }
    }

    class Jogador
    {
        public int Pontuacao { get; set; } = 10;
    }
}

