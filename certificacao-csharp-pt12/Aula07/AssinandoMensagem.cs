using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace certificacao_csharp_pt12.Aula07
{
    class AssinandoMensagem : IExecutavel
    {
        public void Executar()
        {
            var textoOriginal = "Mensagem super secreta do bob";
            Console.WriteLine(textoOriginal);

            Mensagem mensagem = GetMensagemAssinada(textoOriginal);





            ////////
            ///
            /// 
            var valido = ValidarMensagem(mensagem);

            if (valido)
            {
                Console.WriteLine("Mensagem é válida!");
            }
            else
            {
                Console.WriteLine("Mensagem não é válida!");
            }
        
        }

        private bool ValidarMensagem(Mensagem mensagem)
        {
            bool assinaturaValida = false;
            var mensagembytes = GetMensagemBytes(mensagem.mensagem);
            var hash = GetHash(mensagembytes);
            var certificate = GetCertificado();

            RSA descritadorRSA = certificate.GetRSAPublicKey();
            assinaturaValida = descritadorRSA.VerifyHash(hash, mensagem.assinatura, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
            return assinaturaValida;
        }

        private Mensagem GetMensagemAssinada(string mensagem)
        {
            X509Certificate2 certificate = GetCertificado();
            byte[] assinatura = GetAssinatura(mensagem, certificate);

            return new Mensagem(mensagem, assinatura);
        }

        private byte[] GetAssinatura(string mensagem, X509Certificate2 certificate)
        {
            // Obtém um encriptador a partir da chave privada.
            RSA encriptadorRSA = certificate.GetRSAPrivateKey();

            byte[] mensagemBytes = GetMensagemBytes(mensagem);
            byte[] hash = GetHash(mensagemBytes);

            byte[] assinatura = encriptadorRSA.SignHash(hash, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
            ExibirBytes("Assinatura: ", assinatura);
            return assinatura;


        }

        private void ExibirBytes(string titulo, byte[] bytes)
        {
            Console.WriteLine();
            Console.WriteLine(titulo);
            Console.WriteLine();

            foreach(byte b in bytes)
            {
                Console.Write("{0:X} ",b);
            }
            Console.WriteLine();
        }

        private byte[] GetHash(byte[] mensagemBytes)
        {
            HashAlgorithm hasher = new SHA1Managed();

            byte[] hash = hasher.ComputeHash(mensagemBytes);
            return hash;
        }

        private byte[] GetMensagemBytes(string mensagem)
        {
            return ASCIIEncoding.ASCII.GetBytes(mensagem);
        }

        private X509Certificate2 GetCertificado()
        {
            // Converte a string de entrada em bytes
            ASCIIEncoding converter = new ASCIIEncoding();

            // Obter provide de criptografia a partir do nome da store de certificados
            X509Store store = new X509Store("MeuStore", StoreLocation.CurrentUser);

            // aber o store
            store.Open(OpenFlags.ReadOnly);

            // Obtém primeiro certificado
            X509Certificate2 certificate = store.Certificates[0];

            return certificate;
        }
    }


    class Mensagem
    {
        public string mensagem;
        public byte[] assinatura;

        public Mensagem(string mensagem, byte[] assinatura)
        {
            this.mensagem = mensagem;
            this.assinatura = assinatura;
        }
    }
}
