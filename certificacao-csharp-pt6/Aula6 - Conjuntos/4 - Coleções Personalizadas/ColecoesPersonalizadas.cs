using Curso.Arquitetura.Menu;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace certificacao_csharp_pt6.Aula6
{
    class ColecoesPersonalizadas : IExecutavel
    {
        private static PlacasDeCarro Placas = new PlacasDeCarro();

        public void Executar()
        {
            Placas.Add("FNO-7755");
            Placas.Add("FDP-2589");
            Placas.Add("ASX-5236");
            //Placas.Add("ASX-5X36");

            foreach(var placa in Placas)
            {
                Console.WriteLine(placa);
            }


        }


        private class PlacasDeCarro : ICollection<string>
        {
            private IList<string> placas = new List<string>();

            public int Count => placas.Count;

            public bool IsReadOnly => false;

            public void Add(string item)
            {
                if (!EhPlacaValida(item))
                {
                    throw new ArgumentException("Número de placa inválido.", nameof(item));
                }

                placas.Add(item);
            }

            public void Clear()
            {
                placas.Clear();
            }

            public bool Contains(string item)
            {
                return placas.Contains(item);
            }

            public void CopyTo(string[] array, int arrayIndex)
            {
                placas.CopyTo(array, arrayIndex);
            }

            public IEnumerator<string> GetEnumerator()
            {
                return placas.GetEnumerator();
            }

            public bool Remove(string item)
            {
                return placas.Remove(item);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return placas.GetEnumerator();
            }

            private bool EhPlacaValida(string numeroPlaca)
            {
                Regex regex = new Regex(@"^[A-Z]{3}\-\d{4}$");
                return regex.IsMatch(numeroPlaca);
            }
        }
    }




}
