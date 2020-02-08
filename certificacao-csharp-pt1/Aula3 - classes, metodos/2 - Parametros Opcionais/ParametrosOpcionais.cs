using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{

    class ParametrosOpcionais: IExecutavel
    {
        public void Executar()
        {
            ClienteEspecial clienteEspecial = new ClienteEspecial("Lucas Skywalker");
            clienteEspecial.FazerPedido(1, "Residencial", 1);

            clienteEspecial = new ClienteEspecial();
            clienteEspecial.FazerPedido(1, "Residencial", 1);
            clienteEspecial.FazerPedido(2, "Residencial");
            clienteEspecial.FazerPedido(3);

        }
    }

    class ClienteEspecial
    {
        private readonly string nome;

        public ClienteEspecial(string nome = "Anonimo")
        {
            this.nome = nome;
        }

        public void FazerPedido(int produtoId, string endereco = "Residencial", int quantidade = 1)
        {
            Console.WriteLine($"nome: {nome}, produtoId: {produtoId}, endereco: {endereco}, quantidade: {quantidade}");
        }
    }

}
