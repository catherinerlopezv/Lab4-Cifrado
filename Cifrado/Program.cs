using System;
using System.Collections.Generic;
using System.IO;
namespace Cifrado
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Escribir texto: ");
            string texto = Console.ReadLine();
            Console.Write("Escribir llave: ");
            string llave = Console.ReadLine();
            Console.Write("Escribir numero: ");
            int tamaño = Convert.ToInt32(Console.ReadLine());
            Cesar cifradoC = new Cesar(llave, texto);
            string txtcifradoC = cifradoC.Cifrado();
            txtcifradoC = txtcifradoC.Replace("┼", "");
            string raiz = @"..\\..\\..\\cifrado.Caesar";
            using (StreamWriter outputFile = new StreamWriter(raiz))
            {
                foreach (char caracter in txtcifradoC)
                {
                    outputFile.Write(caracter.ToString());
                }

            }
            ZigZagCifrar cifradoZ = new ZigZagCifrar(tamaño, texto);
            string txtcifradoZ = cifradoZ.Cifrado();
            txtcifradoZ = txtcifradoZ.Replace("┼", "");

            raiz = @"..\\..\\..\\cifrado.ZigZag";
            using (StreamWriter outputFile = new StreamWriter(raiz))
            {
                foreach (char caracter in txtcifradoZ)
                {
                    outputFile.Write(caracter.ToString());
                }
            }

            Console.WriteLine("Archivos creados y cifrados!, revisar carpeta");
            bool correcto = false;
            while (!correcto)
            {
                Console.WriteLine("Escribir llave para descifrar: ");
                string llaveDes = Console.ReadLine();
                if (llaveDes == llave)
                {
                    Cesar descifradoC = new Cesar(llave, txtcifradoC);
                    string txtdescifradoC = descifradoC.Descifrado();
                    txtdescifradoC = txtdescifradoC.Replace("┼", "");
                    txtdescifradoC = txtdescifradoC.Replace("↔", "");
                    raiz = @"..\\..\\..\\Caesar.txt";
                    using (StreamWriter outputFile = new StreamWriter(raiz))
                    {
                        foreach (char caracter in txtdescifradoC)
                        {
                            outputFile.Write(caracter.ToString());
                        }
                    }
                    correcto = true;

                }
                else
                {
                    Console.WriteLine("Llave incorrecta, la llave empezaba por: " + llave.Substring(0, 1) + ", y es de tamaño:" + llave.Length);
                }


            }
            bool uwu = false;
            while (!uwu)
            {
                Console.WriteLine("Escribir numero para descifrar: ");
                int llaveDes = Convert.ToInt32(Console.ReadLine());
                if (llaveDes == tamaño)
                {
                    ZigZagDescifrar descifrado = new ZigZagDescifrar(llaveDes, txtcifradoZ);
                    string txtdescifrado = descifrado.Descifrado();
                    txtdescifrado = txtdescifrado.Replace("┼", "");
                    raiz = @"..\\..\\..\\ZigZag.txt";
                    txtdescifrado = txtdescifrado.Replace("↔", "");
                    using (StreamWriter outputFile = new StreamWriter(raiz))
                    {
                        foreach (char caracter in txtdescifrado)
                        {
                            outputFile.Write(caracter.ToString());

                        }
                    }
                    uwu = true;

                }
                else
                {
                    Console.WriteLine("Numero incorrecto");
                }


            }












            Console.WriteLine("Archivos creados y descifrados!, revisar carpeta");






        }
    }
}
