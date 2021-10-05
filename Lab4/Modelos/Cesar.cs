using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections;
using System.IO;
using System.Text;


namespace Lab4
{

    public class Cesar
    {
        public string Palabra;
        public string Texto;
        public List<char> ListaPalabra;
        public List<char> Abecedario;
        public List<char> ListaTexto = new List<char>();
        public List<char> ListaCifrada = new List<char>();
        public Dictionary<char, char> DicccionarioCifrado = new Dictionary<char, char>();
        public Cesar(string palabra, string texto)
        {
            Palabra = palabra;
            Texto = texto;
            Abecedario = "abcdefghijklmnñopqrstuvwxyz".ToArray().ToList();
            ListaTexto = Texto.ToArray().ToList();
        }

        public string Cifrado()
        {
            int posicion = 0;
            string cifrado = "";
            PalabraAbecedario();
            for (int i = 0; i < ListaTexto.Count(); i++)
            {
                if (Abecedario.Contains(ListaTexto.ElementAt(i)))
                {
                    posicion = Abecedario.IndexOf(ListaTexto.ElementAt(i));
                    ListaCifrada.Add(ListaPalabra.ElementAt(posicion));
                }
                else
                {
                    ListaCifrada.Add(ListaTexto.ElementAt(i));
                }

            }
            cifrado = string.Join('↔', ListaCifrada);
            cifrado = cifrado.Replace("↔", "");
            return cifrado;
        }

        public string Descifrado()
        {
            int posicion = 0;
            string descifrado = "";
            PalabraAbecedario();
            for (int i = 0; i < ListaTexto.Count(); i++)
            {
                if (ListaPalabra.Contains(ListaTexto.ElementAt(i)))
                {
                    posicion = ListaPalabra.IndexOf(ListaTexto.ElementAt(i));
                    ListaCifrada.Add(Abecedario.ElementAt(posicion));
                }
                else
                {
                    ListaCifrada.Add(ListaTexto.ElementAt(i));
                }

            }
            descifrado = string.Join('↔', ListaCifrada);
            descifrado = descifrado.Replace("↔", "");
            return descifrado;
        }

        public void PalabraAbecedario()
        {
            ListaPalabra = Palabra.ToArray().ToList();
            ListaPalabra = ((from s in ListaPalabra select s).Distinct()).ToList();
            ListaPalabra = ListaPalabra.Union(Abecedario).ToList();
            ListaPalabra = ((from s in ListaPalabra select s).Distinct()).ToList();

        }


    }

}
