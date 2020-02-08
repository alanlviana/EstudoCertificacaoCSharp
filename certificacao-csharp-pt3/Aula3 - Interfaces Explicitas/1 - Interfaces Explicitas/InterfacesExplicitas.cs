using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt3.Aula3
{
    class InterfacesExplicitas : IExecutavel
    {
        public void Executar()
        {
            IFuncionario funcionario = new Funcionario(1500);
            funcionario.CPF = "123.456.789-00";
            funcionario.Nome = "José da Silva";
            funcionario.DataNascimento = new DateTime(2000, 1, 1);

            

            funcionario.CargaHorariaMensal = 168;
            funcionario.EfetuarPagamento();
            funcionario.CrachaGerado += Funcionario_CrachaGerado;

            IPlantonista plantonista = (IPlantonista)funcionario;
            plantonista.GerarCracha();
            funcionario.GerarCracha();
        }

        private void Funcionario_CrachaGerado(object sender, EventArgs e)
        {
            Console.WriteLine("Crachá gerado!");
        }
    }

    interface IFuncionario
    {
        string CPF { get; set; }
        string Nome { get; set; }
        DateTime DataNascimento { get; set; }

        event EventHandler CrachaGerado;

        void GerarCracha();

        decimal Salario { get; }
        int CargaHorariaMensal { get; set; }
        void EfetuarPagamento();
    }

    interface IPlantonista
    {
        int CargaHorariaMensal { get; set; }
        void GerarCracha();
    }

    class Funcionario: IFuncionario, IPlantonista
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public event EventHandler CrachaGerado;

        void IPlantonista.GerarCracha() {
            Console.WriteLine("Crachá de plantonista gerado!");
            CrachaGerado.Invoke(this, EventArgs.Empty);
        }

        void IFuncionario.GerarCracha()
        {
            Console.WriteLine("Crachá de funcionario gerado!");
            CrachaGerado.Invoke(this, EventArgs.Empty);
        }


        public decimal Salario { get; }
        int IFuncionario.CargaHorariaMensal { get; set; }
        int IPlantonista.CargaHorariaMensal { get; set; }
        public Funcionario(decimal salario) { }
        public void EfetuarPagamento() { }
    }

}
