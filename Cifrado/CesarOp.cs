using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cifrado
{
    public class CesarOp
    {
        public static void Cifrado(string path, string raiz, string palabra)
        {
            string texto = System.IO.File.ReadAllText(@path);
            Cesar cifrado = new Cesar(palabra, texto);
            string txtcifrado = cifrado.Cifrado();

            List<char> bytecompress = new List<char>();

            raiz = raiz + @"\\Upload\\" + Path.GetFileNameWithoutExtension(path) + ".cesar";
            using (StreamWriter outputFile = new StreamWriter(raiz))
            {
                foreach (char caracter in txtcifrado)
                {
                    outputFile.Write(caracter.ToString());
                }

            }
        }

        public static void Descifrado(string path, string root, string palabra)
        {
            string texto = System.IO.File.ReadAllText(@path);
            Cesar descifrado = new Cesar(palabra, texto);
            string txtdescifrado = descifrado.Descifrado();
            txtdescifrado.Replace("ascii 197", "");

            root = root + @"\\Upload\\" + Path.GetFileNameWithoutExtension(path) + ".txt";
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
