using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt4.Item4
{
    class Foreach : IExecutavel
    {
        public void Executar()
        {
            ImprimirClientes("Clientes", getClientes());
            ImprimirClientes("Clientes Especiais", getClientesEspeciais());

        }

        private void ImprimirClientes(string titulo, IList<Cliente> clientes)
        {
            Console.WriteLine(titulo);
            Console.WriteLine();

            foreach(var cliente in clientes)
            {
                Console.WriteLine($"{cliente.Nome}");
            }
        }

        private IList<Cliente> getClientes() {
            var clientes = new List<Cliente>()
            {
                new Cliente("Zé das Couves", new List<ContaBancaria>{
                    new ContaBancaria(200),
                    new ContaBancaria(500),
                    new ContaBancaria(700),
                    new ContaBancaria(800),
                }),
                new Cliente("Gino", new List<ContaBancaria>{
                    new ContaBancaria(200),
                    new ContaBancaria(500),
                }),
                new Cliente("Maria Aparecida", new List<ContaBancaria>{
                    new ContaBancaria(200),
                    new ContaBancaria(400),
                    new ContaBancaria(500),
                })
            };

            return clientes;
            
        }

        private IList<Cliente> getClientesEspeciais()
        {
            var clientes = getClientes();
            var clientesEspeciais = new List<Cliente>();

            foreach(var cliente in clientes)
            {
                var saldoAgrupado = 0m;
                foreach(var conta in cliente.Contas)
                {
                    saldoAgrupado += conta.Saldo;
                }

                if (saldoAgrupado > 1000)
                {
                    clientesEspeciais.Add(cliente);
                }

            }

            return clientesEspeciais;
        }

    }

    class Cliente {
        public Cliente(string nome, IList<ContaBancaria> contas)
        {
            Nome = nome;
            Contas = contas;
        }

        public string Nome { get; set; }
        public IList<ContaBancaria> Contas { get; set; }



    }
}