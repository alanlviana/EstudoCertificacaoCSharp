using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.IO;
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

            Console.WriteLine($"Valor de juros para {6000:C} em 4 anos é {emprestimo.CalcularJuros(6000, 4):C}");
            Console.WriteLine($"Valor de juros para {6000:C} em 7 anos é {emprestimo.CalcularJuros(6000, 7):C}");

        }

    }

    class Emprestimo {

#if (DEBUG)
        private static readonly string ARQUIVO_LOG = @"monitoramento/log.txt";
#else
        private static readonly string ARQUIVO_LOG = @"monitoramento/log_producao.txt";
#endif
        //private static readonly string ARQUIVO_LOG_TESTE = @"monitoramento/teste";


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
                    OnPrazoMaximoEstourado?.Invoke(this, EventArgs.Empty);
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

        internal decimal CalcularJuros(int valorEmprestimo, int prazo)
        {
            decimal valorJuros;
            decimal taxaJuros = 0; // RetornaTaxa(valorEmprestimo, prazo);

            if (prazo> 0 && prazo < 5 && valorEmprestimo < 7000)
            {
                taxaJuros = 0.035m;
            }
            else
            {
                if (prazo > 5 && valorEmprestimo > 7000)
                {
                    taxaJuros = 0.075m;
                }
                else
                {
                    taxaJuros = 0.0875m;
                }
            }

            valorJuros = valorEmprestimo * taxaJuros * prazo;

            GravarLog($"O valor calculado de juros é {valorJuros:C}");

            return valorJuros;
        }

        private void GravarLog(string mensagem)
        {
            Console.WriteLine(mensagem);
            var caminhoArquivo = ARQUIVO_LOG;
            var caminhoDiretorio = Path.GetDirectoryName(caminhoArquivo);
            Directory.CreateDirectory(caminhoDiretorio);

            File.AppendAllText(caminhoArquivo, mensagem + Environment.NewLine);
        }

        private static decimal RetornaTaxa(int valorEmprestimo, int prazo)
        {
            if (prazo > 0 && prazo < 5 && valorEmprestimo < 7000)
            {
                return 0.035m;
            }

            if (prazo > 5 && valorEmprestimo > 7000)
            {
                return 0.075m;
            }

            return 0.0875m;
        }

        public void Finalizar()
        {
#if(TRIAL)
            AvaliarEmprestimo();
#elif (BASIC)
            AvaliarEmprestimo();
            ProcessarEmprestimo();
            FinalizarEmprestimo();

#elif (ADVANCED)
            AvaliarEmprestimo();
            ProcessarEmprestimo();
#endif
        }

        private void FinalizarEmprestimo()
        {
            GravarLog("Emprestimo Finalizado.");
        }

        private void ProcessarEmprestimo()
        {
            GravarLog("Emprestimo processado.");
        }

        private void AvaliarEmprestimo()
        {
            GravarLog("Emprestimo Avaliado.");
        }
    }


}
