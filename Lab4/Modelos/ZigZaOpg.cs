using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4
{
    public static class ZigZaOpg
    {
        public static void Cifrado(string path, string root, int niveles)
        {
            string texto = System.IO.File.ReadAllText(@path);
            ZigZagCifrar cifrado = new ZigZagCifrar(niveles, texto);
            string txtcifrado =cifrado.Cifrado();

            List<char> bytecompress = new List<char>();


            root = root + @"\\Upload\\cifrado.zz";
            using (StreamWriter outputFile = new StreamWriter(root))
            {
                foreach (char caracter in txtcifrado)
                {
                    outputFile.Write(caracter.ToString());
                }
            }
        }

        public static void Descifrado(string path, string root, int niveles)
        {
            string texto = System.IO.File.ReadAllText(@path);
            ZigZagDescifrar descifrado = new ZigZagDescifrar(niveles, texto);
            string txtdescifrado = descifrado.Descifrado();
            txtdescifrado.Replace("ascii 197", "");

            root = root + @"\\Upload\\descifradoZigZag.txt";
            using (StreamWriter outputFile = new StreamWriter(root))
            {
                foreach (char caracter in txtdescifrado)
                {
                    outputFile.Write(caracter.ToString());
                    
                }
            }
        }
    }
}
