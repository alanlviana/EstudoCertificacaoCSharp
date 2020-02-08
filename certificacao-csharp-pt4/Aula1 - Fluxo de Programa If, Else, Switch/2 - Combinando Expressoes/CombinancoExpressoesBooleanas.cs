using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt4
{
    class CombinandoExpressoesBooleanas : IExecutavel
    {
        public void Executar()
        {
            var emprestimo = new Emprestimo("XPTO1");
            emprestimo.OnPrazoMaximoEstourado += (sender, e) =>
            {
                Console.WriteLine("Prazo máximo estourado.");
            };

            emprestimo.Prazo = 3;
            emprestimo.Prazo = 6;

        }

    }

    class Emprestimo {

        public delegate void PrazoMaximoEstouradoHandler(object sender, EventArgs args);

        private readonly static int PRAZO_MAXIMO_PAGAMENTO_ANOS = 5;

        private int prazo;

        public string CodigoEmprestimo { get; set; }
        public event PrazoMaximoEstouradoHandler OnPrazoMaximoEstourado;

        public int Prazo { 
            get => prazo;
            set {
                if (value > PRAZO_MAXIMO_PAGAMENTO_ANOS)
                {
                    //throw new ArgumentException($"Prazo não pode ser maior que {PRAZO_MAXIMO_PAGAMENTO_ANOS}.", nameof(Prazo));
                    if (OnPrazoMaximoEstourado != null)
                    {
                        OnPrazoMaximoEstourado(this, EventArgs.Empty);
                    }
                    return;
                }

                prazo = value;
                Console.WriteLine($"Novo prazo do emprestimo: {Prazo}");

            }
        }

        public Emprestimo(string codigoEmprestimo)
        {
            if (!ValidarCodigo(codigoEmprestimo))
            {
                throw new ArgumentException("Código do emprestimo é inválido.", nameof(codigoEmprestimo));
            }

            this.CodigoEmprestimo = codigoEmprestimo;

            Console.WriteLine($"Novo emprestimo criado com código {CodigoEmprestimo}");
        }

        /// <summary>
        /// Deve ser válido se for numérico ou maiúscula
        /// </summary>
        /// <param name="codigoContrato">Código do contrato</param>
        /// <returns></returns>
        private bool ValidarCodigo(string codigoContrato)
        {
            bool codigoContratoValido = true;
            foreach (var caractere in codigoContrato)
            {
                var numerico = Char.IsDigit(caractere);
                var maiuscula = Char.IsUpper(caractere);

                bool valido = numerico || maiuscula;
                if (!(valido))
                {
                    codigoContratoValido = false;
                    break;
                }
            }

            return codigoContratoValido;
        }
    }


}
