using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace certificacao_csharp_pt5.aula4
{
    class StringWriterExemplo : IExecutavel
    {
        public void Executar()
        {
            var ingredientes = GetIngredientes();

            using (var stringWriter = new StringWriter())
            {
                using (var reader = new StringReader(ingredientes))
                {
                    Console.OutputEncoding = System.Text.Encoding.UTF8;

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        stringWriter.WriteLine("•" + line);
                    }
                }

                Console.WriteLine(stringWriter);
            }


        }

        private string GetIngredientes()
        {
            return @"Jaca
Maça
Uva
Banana
Leite Condensado";
        }
    }
}
