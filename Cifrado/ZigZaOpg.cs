using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cifrado
{
    public static class ZigZaOpg
    {
        public static void Cifrado(IFormFile file, string path,string raiz, int niveles)
        {
            ZigZagCifrar cifrado = new ZigZagCifrar();

            cifrado.Cifrar(file,niveles,raiz);


          
        }

        public static void Descifrado(IFormFile file, string path, string raiz, int niveles)
        {
            ZigZagCifrar cifrado = new ZigZagCifrar();

            cifrado.Decifrar(file, niveles, raiz);
        }
    }
}
