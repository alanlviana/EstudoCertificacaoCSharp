using certificacao_csharp_pt10._3TiposSystemReflection.Modelo;
using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace certificacao_csharp_pt10._3TiposSystemReflection
{
    class TiposSystemReflection : IExecutavel
    {
        public void Executar()
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            var fullnameExecutingAssembly = executingAssembly.FullName;
            var versionExecutingAssembly = executingAssembly.GetName().Version;
            var isGAC = executingAssembly.GlobalAssemblyCache;
            var modulesAssembly = executingAssembly.GetModules();

            Console.WriteLine($"Nome do Assembly: {fullnameExecutingAssembly}");
            Console.WriteLine($"Versão do Assembly: {versionExecutingAssembly}");
            Console.WriteLine($"Versão Maior do Assembly: {versionExecutingAssembly.Major}");
            Console.WriteLine($"Versão Menor do Assembly: {versionExecutingAssembly.Minor}");
            Console.WriteLine($"Está no GAC: {isGAC}");
            Console.WriteLine();
            Console.WriteLine("Lista dos Módulos:");
            foreach(var module in modulesAssembly)
            {
                Console.WriteLine(module);
                var typesModule = module.GetTypes();
                Console.WriteLine("\tLista dos tipos:");
                foreach (var type in typesModule)
                {
                    Console.WriteLine("\t"+type);
                    Console.WriteLine("\t\tLista dos membros:");
                    var membersType = type.GetMembers();
                    foreach(var member in membersType)
                    {
                        Console.WriteLine("\t\t"+member);
                    }

                }
            }

            Type tipoCarrinhoCliente = typeof(CarrinhoCliente);
            var propertiesCarrinhoCliente = tipoCarrinhoCliente.GetProperties();

            Console.WriteLine();
            Console.WriteLine("Propriedades carrinho cliente:");
            foreach(var property in propertiesCarrinhoCliente)
            {
                Console.WriteLine(property);

                Console.WriteLine(property.GetGetMethod());

                Console.WriteLine(property.GetSetMethod());
            }


            Console.WriteLine();

        }
    }
}
