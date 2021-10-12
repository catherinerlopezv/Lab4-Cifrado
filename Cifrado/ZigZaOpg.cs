using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cifrado
{
    public static class ZigZaOpg
    {
        public static void Cifrado(string path, string root, int niveles)
        {
            string texto = System.IO.File.ReadAllText(@path);
            ZigZagCifrar cifrado = new ZigZagCifrar(niveles, texto);
            string txtcifrado =cifrado.Cifrado();


            root = root + @"\\Upload\\" + Path.GetFileNameWithoutExtension(path) + ".ZigZag";
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

            root = root +@"\\Upload\\" + Path.GetFileNameWithoutExtension(path) + ".txt";
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
