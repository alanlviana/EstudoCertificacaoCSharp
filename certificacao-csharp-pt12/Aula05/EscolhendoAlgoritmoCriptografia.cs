using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace certificacao_csharp_pt12.Aula05
{
    class EscolhendoAlgoritmoCriptografia : IExecutavel
    {
        public void Executar()
        {

            // AES = Advanced Encryption Stadard
            string mensagemSecreta = "Informações secretas são secretas.";
            string mensagemSecretaDescifrado = "";

            byte[] mensagemCriptografadaBytes = new byte[0];


            byte[] chave = new byte[0];
            byte[] vetorInicializacao = new byte[0];
            
            using (var aes = Aes.Create())
            {
                chave = aes.Key;
                vetorInicializacao = aes.IV;
                
                ICryptoTransform crypto = aes.CreateEncryptor();
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, crypto, CryptoStreamMode.Write))
                    {
                        using (var streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(mensagemSecreta);
                        }
                    }

                    mensagemCriptografadaBytes = memoryStream.ToArray();
                }

            }

            Console.WriteLine("Mensagem Original:");
            Console.WriteLine(mensagemSecreta);

            Console.WriteLine("Chave");
            ExibirBytes(chave);

            Console.WriteLine("Mensagem Criptografada");
            ExibirBytes(mensagemCriptografadaBytes);

            Console.WriteLine();
            Console.WriteLine("Descriptografando...");
            Console.WriteLine();

            using (var aes = Aes.Create())
            {
                aes.Key = chave;
                aes.IV = vetorInicializacao;

                ICryptoTransform descrypto = aes.CreateDecryptor();
                using(var memoryStream = new MemoryStream(mensagemCriptografadaBytes))
                {
                    using (var criptoStream = new CryptoStream(memoryStream, descrypto, CryptoStreamMode.Read))
                    {
                        using (var streamReader = new StreamReader(criptoStream))
                        {
                            mensagemSecretaDescifrado = streamReader.ReadToEnd();

                        }
                    }
                }
            }

            Console.WriteLine("Texto descifrado");
            Console.WriteLine(mensagemSecretaDescifrado);

        }

        private void ExibirBytes(byte[] bytes)
        {
            foreach(var c in bytes)
            {
                Console.Write("{0:X} ", c);
            }
            Console.WriteLine();
        }
    }
}
