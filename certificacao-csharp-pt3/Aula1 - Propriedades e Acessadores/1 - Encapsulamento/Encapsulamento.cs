using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt3
{
    class Encapsulamento : IAulaItem
    {
        public void Executar()
        {
            var funcionario = new Funcionario(1400);
            //funcionario.Salario = 1400;

            Console.WriteLine($"Salário do funcionário é {funcionario.Salario}");

            funcionario = new Funcionario(2000);

            Console.WriteLine($"Novo salário do funcionário é {funcionario.Salario}");


        }


        class Funcionario
        {
            /*
            private decimal salario;
            public decimal Salario
            {
                get
                {
                    return salario;
                }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException("Não é possível definir um salário negativo.", "Salario");
                    }

                    salario = value;
                }
            }

            private decimal salario;

            public decimal Salario
            {
                get { return salario; }
                set {
                    if (value < 0) throw new ArgumentOutOfRangeException("Não é possível definir um salário negativo", "Salario");

                    salario = value; 
                }
            }*/

            public Funcionario(decimal salario)
            {
                Salario = salario;
            }

            public decimal Salario { get; }

            public string Nome { get; set; } // Propriedade auto implementada

        }
    }
}
