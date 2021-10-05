using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4
{
    public class ZigZagDescifrar
    {

        public ZigZagDescifrar(int niveles, string texto)
        {
            this.niveles = niveles;
            Texto = texto;
        }

        public int niveles;
        public string Texto;

        public int TamañoOla()
        {
            int resultado = 0;
            resultado = (niveles * 2) - 2;
            return resultado;
        }
        private int NumeroOlas()
        {
            int resultado = 0;
            resultado = TamañoTexto() / TamañoOla();
            return resultado;

        }
        private int TamañoBloque()
        {
            int resultado = 0;
            resultado = 2 * NumeroOlas();
            return resultado;

        }
        private int TamañoTexto()
        {
            int resultado = 0;
            char[] TamañoTexto = Texto.ToCharArray();
            for (int i = 0; i < TamañoTexto.Length; i++)
            {
                resultado++;
            }
            return resultado;

        }
        private List<char> ListaCaracteresTotales()
        {
            List<char> lista = new List<char>();
            char[] caracteres = Texto.ToCharArray();

            for (int i = 0; i < TamañoTexto(); i++)
            {
                lista.Add(caracteres[i]);
            }

            return lista;
        }
        public List<List<char>> ListaDescifrado()
        {
            List<List<char>> ListasOlas = new List<List<char>>();
            List<char> temporal = ListaCaracteresTotales();


            List<char> ListaAuxiliar = new List<char>();
            for (int j = 0; j < NumeroOlas(); j++)
            {
                ListaAuxiliar.Add(temporal.ElementAt(0));
                temporal.RemoveAt(0);
            }
            ListasOlas.Add(ListaAuxiliar);


            ListaAuxiliar = new List<char>();
            int CantidadBloques = temporal.Count() / TamañoBloque();
            for (int i = 0; i < CantidadBloques; i++)
            {
                ListaAuxiliar = new List<char>();
                for (int j = 0; j < TamañoBloque(); j++)
                {
                    ListaAuxiliar.Add(temporal.ElementAt(0));
                    temporal.RemoveAt(0);
                }
                ListasOlas.Add(ListaAuxiliar);
            }


            ListaAuxiliar = new List<char>();
            int Tamaño = temporal.Count() - 1;
            for (int j = 0; j <= Tamaño; j++)
            {
                ListaAuxiliar.Add(temporal.ElementAt(0));
                temporal.RemoveAt(0);
            }
            ListasOlas.Add(ListaAuxiliar);


            return ListasOlas;
        }
        public string Descifrado()
        {

            String descifrado = "";
            List<List<char>> temporal = ListaDescifrado();

            int comienzo = 0;
            int ultimo = 0;

            int tamaño = temporal.ElementAt(0).Count() - 1;

            tamaño = niveles;
            for (int i = 0; i < 1; i++)
            {

                if (comienzo == 1)
                {
                    tamaño++;
                }

                for (int r = 0; r < NumeroOlas(); r++)
                {

                    for (int j = comienzo; j < tamaño; j++)
                    {
                        descifrado = descifrado + temporal.ElementAt(j).ElementAt(0).ToString();
                        temporal.ElementAt(j).RemoveAt(0);
                        ultimo = j;
                    }
                    if (i == 0)
                    {
                        ultimo = ultimo - 1;
                    }
                    for (int x = ultimo; x >= 0; x--)
                    {

                        if (temporal.ElementAt(x).Count() != 0)
                        {
                            descifrado = descifrado + temporal.ElementAt(x).ElementAt(0).ToString();
                            temporal.ElementAt(x).RemoveAt(0);
                            if (temporal.ElementAt(x).Count() == 0)
                            {
                                x = x - 1;
                            }

                        }
                        else
                        {
                            x = x - 1;
                        }
                    }
                    comienzo = 0;
                    comienzo = comienzo + 1;

                }

            }

            return descifrado;
        }

    }
}
