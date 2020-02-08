using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt3.Aula4
{
    class ClasseBase : IAulaItem
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

            Cliente cliente = new Cliente()
            {
                CPF = "789.456.123-90",
                Nome = "Maria de Souza",
                DataNascimento = new DateTime(1970, 04, 01),
                DataUltimaCompra = new DateTime(2020, 02, 05),
                ValorUltimaCompra = 20
            };

            Console.WriteLine(cliente);
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

    class Funcionario: Pessoa, IFuncionario, IPlantonista
    {
        
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

    abstract class Pessoa
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
    // sealed indica que uma classe não pode ser herdada
    sealed class Cliente : Pessoa
    {


        public DateTime? DataUltimaCompra { get; set; }
        public decimal? ValorUltimaCompra { get; set; }

        public override string ToString()
        {
            return $"Nome: {Nome},CPF: {CPF}, DataNascimento: {DataNascimento}, DataUltimaCompra: {DataUltimaCompra}, ValorUltimaCompra: {ValorUltimaCompra}";
        }
    }

}
