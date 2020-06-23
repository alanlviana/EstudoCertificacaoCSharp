using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace certificacao_csharp_pt12.Aula05
{
    class EscolhendoAlgoritmoCriptografiaAssimetrica : IExecutavel
    {
        public void Executar()
        {
            // Alice quer mandar uma mensagem criptograda para Bob
            var mensagem = "Chaves privadas não podem trafegar na rede!";

            //
            var alice = new Pessoa("Alice");
            alice.ImprimirChaves();
            var bob = new Pessoa("Bob");
            bob.ImprimirChaves();

            alice.ReiniciarChaves();
            bob.ReiniciarChaves();

            alice = new Pessoa("Alice");
            alice.ImprimirChaves();
            bob = new Pessoa("Bob");
            bob.ImprimirChaves();


            var chavePublicaBob = bob.ChavePublica;
            byte[] bytesMensagem = new UTF8Encoding().GetBytes(mensagem);
            byte[] mensagemCriptografadaParaBob = alice.CodificarMensagem(bytesMensagem, chavePublicaBob);

            // Mensagem sendo enviada para BOB

            byte[] mensagemDescriptografadaPorBob = bob.DecodificarMensagem(mensagemCriptografadaParaBob);
            var textoParaBob = UTF8Encoding.UTF8.GetString(mensagemDescriptografadaPorBob);
            Console.WriteLine($"Texto descriptografado por bob: {textoParaBob}");






        }
    }

    class Pessoa
    {
        public string Nome { get; set; }
        private string _chavePrivada;
        public string ChavePublica { get; }

        public Pessoa(string nome)
        {
            Nome = nome;

            CspParameters cspParameters = new CspParameters();
            cspParameters.KeyContainerName = nome;

            RSACryptoServiceProvider encriptadorRSA = new RSACryptoServiceProvider(cspParameters);
            ChavePublica = encriptadorRSA.ToXmlString(false);
            _chavePrivada = encriptadorRSA.ToXmlString(true);

        }

        public void ImprimirChaves()
        {
            Console.WriteLine($">>>> PESSOA ({Nome}) <<<<<<");
            Console.WriteLine($">>>> Chave Privada ({Nome}) <<<<<<");
            Console.WriteLine(_chavePrivada);
            Console.WriteLine($">>>> Chave Publica ({Nome}) <<<<<<");
            Console.WriteLine(ChavePublica);
        }

        public void ReiniciarChaves()
        {
            CspParameters cspParameters = new CspParameters();
            cspParameters.KeyContainerName = Nome;
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspParameters);
            rsa.PersistKeyInCsp = false;
            rsa.Clear();
        }

        public byte[] CodificarMensagem(byte[] mensagemCriptografada, string chavePublicaDestinatario)
        {

            RSACryptoServiceProvider encriptadorRSA = new RSACryptoServiceProvider();
            encriptadorRSA.FromXmlString(chavePublicaDestinatario);

            byte[] bytesCodificados = encriptadorRSA.Encrypt(mensagemCriptografada, false);
            return bytesCodificados;
        }


        public byte[] DecodificarMensagem(byte[] mensagemCriptografada)
        {
            CspParameters cspParameters = new CspParameters();
            cspParameters.KeyContainerName = Nome;
            RSACryptoServiceProvider descriptadorRSA = new RSACryptoServiceProvider(cspParameters);
            descriptadorRSA.FromXmlString(_chavePrivada);

            byte[] mensagemDescriptografada = descriptadorRSA.Decrypt(mensagemCriptografada, false);
            return mensagemDescriptografada;
        }

    }




}
