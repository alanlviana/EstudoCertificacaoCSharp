using System;
using System.Collections;
using System.Collections.Generic;

namespace Curso.Arquitetura.Menu
{
    public abstract class Menu: IExecutavel
    {
        public void Executar()
        {
            ImprimirMenu();
        }

        private void ImprimirMenu()
        {
            IExecutavel itemSelecionado;
            var menuItems = GetMenuItems();

            while (true)
            {
                ImprimirMenuItems(menuItems);
                var opcao = Console.ReadLine();

                int.TryParse(opcao, out int valorOpcao);

                if (valorOpcao == 0)
                {
                    break;
                }

                if (valorOpcao > menuItems.Count)
                {
                    break;
                }

                itemSelecionado = Executar(valorOpcao);
                Console.ReadKey();
            }
        }

        protected abstract IList<MenuItem> GetMenuItems();

        private IExecutavel Executar(int valorOpcao)
        {
            Console.Clear();
            IExecutavel itemSelecionado;
            var menuItems = GetMenuItems();
            MenuItem menuItem = menuItems[valorOpcao - 1];
            Type tipoClasse = menuItem.TipoClasse;
            itemSelecionado = (IExecutavel)Activator.CreateInstance(tipoClasse);


            string titulo = $"EXECUTANDO: {menuItem.Titulo}";
            Console.WriteLine(titulo);
            Console.WriteLine(new string('=', titulo.Length));
            try { 
                itemSelecionado.Executar();
            }catch(Exception e)
            {
                Console.WriteLine($"Falha ao executar {menuItem.Titulo}: {e}");

            }
            Console.WriteLine();
            Console.WriteLine("Tecle algo para continuar...");
            return itemSelecionado;
        }

        private static void ImprimirMenuItems(IList<MenuItem> menuItems)
        {
            Console.Clear();
            int i = 1;
            Console.WriteLine("SELECIONE UMA OPÇÃO");
            Console.WriteLine("===================");
            
            foreach (var menuItem in menuItems)
            {
                Console.WriteLine((i++).ToString() + " - " + menuItem.Titulo);
            }

            Console.WriteLine("0 - Sair");
        }


    }
}
