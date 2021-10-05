using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cifrado
{
    public class ZigZagCifrar
    {
        public ZigZagCifrar(int niveles, string texto)
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
        public List<List<char>> ListasCifrado()
        {
            List<List<char>> ListasOlas = new List<List<char>>();
            char[] TamañoText = Texto.ToCharArray();
            char res = ' ';
            List<char> Temporal = ListaCaracteresTotales();
            for (int i = 0; i <= NumeroOlas(); i++)
            {
                List<char> ListaPrueba = new List<char>();

                if (Temporal.Count() != 0)
                {
                    for (int j = 0; j < TamañoOla(); j++)
                    {

                        res = Temporal.ElementAt(0);
                        Temporal.RemoveAt(0);
                        ListaPrueba.Add(res);
                        if (Temporal.Count() == 0)
                        {
                            int tamaño = TamañoOla() - ListaPrueba.Count();
                            for (int h = 0; h < tamaño; h++)
                            {
                                ListaPrueba.Add('|');

                            }
                            j = TamañoOla() + 1;
                        }
                    }
                    ListasOlas.Add(ListaPrueba);
                }
                else
                {
                    ListaPrueba.Add('1');
                }
            }
            return ListasOlas;
        }
        public string Cifrado()
        {

            string cifrado = "";
            List<List<char>> temporal = ListasCifrado();

            int ultimo = 0;
            ultimo = TamañoOla() - 3;
            for (int i = 0; i <= ListasCifrado().ElementAt(0).Count() - 1; i++)
            {

                for (int j = 0; j <= NumeroOlas(); j++)
                {

                    if (j == 0 && i == 0)
                    {
                        for (int x = 0; x <= NumeroOlas(); x++)
                        {

                            cifrado = cifrado + temporal.ElementAt(x).ElementAt(i).ToString();
                            temporal.ElementAt(x).RemoveAt(i);

                        }

                    }


                    if ((temporal.ElementAt(j).Count() - 1) >= 0)
                    {
                        cifrado = cifrado + temporal.ElementAt(j).ElementAt(0).ToString();
                        temporal.ElementAt(j).RemoveAt(0);
                    }
                    if ((temporal.ElementAt(j).Count() - 1) > 0)
                    {
                        cifrado = cifrado + temporal.ElementAt(j).ElementAt(temporal.ElementAt(j).Count() - 1).ToString();
                        temporal.ElementAt(j).RemoveAt(temporal.ElementAt(j).Count() - 1);
                    }


                }

            }
            return cifrado;
        }

    }
}
