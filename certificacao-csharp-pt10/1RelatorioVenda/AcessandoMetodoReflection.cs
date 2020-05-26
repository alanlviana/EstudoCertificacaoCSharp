using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace certificacao_csharp_pt10._1RelatorioVenda
{
    class AcessandoMetodoReflection : IExecutavel
    {
        public void Executar()
        {
            var relatorio = new Relatorio();
            var tipo = relatorio.GetType();
            Console.WriteLine("Obtendo tipo do relatório:");
            Console.WriteLine(tipo);

            Console.WriteLine();
            Console.WriteLine("Obtendo membros do relatório:");
            var membros = tipo.GetMembers();
            foreach(var memberInfo in membros)
            {
                Console.WriteLine(memberInfo);
            }


            Console.WriteLine();
            Console.WriteLine("Alterando nome via reflection");
            var metodoSetNome = tipo.GetMethod("set_Nome");
            metodoSetNome.Invoke(relatorio,new []{"Relatório criado via reflection!"});

            var metodoImprimir = tipo.GetMethod("Imprimir");
            metodoImprimir.Invoke(relatorio, new object[] { });

            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            var tiposAssembly = executingAssembly.GetTypes();
            
            Console.WriteLine();
            Console.WriteLine("Todos os tipos executáveis do assembly:");
            foreach(var tipoAssembly in tiposAssembly.Where(t => typeof(IExecutavel).IsAssignableFrom(t)))
            {
                Console.WriteLine(tipoAssembly);
            }

            Console.WriteLine();
            Console.WriteLine("Todos os tipos classe do assembly:");
            foreach (var tipoAssembly in tiposAssembly.Where(t => t.IsClass))
            {
                Console.WriteLine(tipoAssembly);
            }



        }
    }
}
