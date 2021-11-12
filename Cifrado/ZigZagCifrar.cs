using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cifrado
{
    public class ZigZagCifrar
    {
        public  void Cifrar(IFormFile archivo, int niveles,string raiz)
        {
            string nombre = Path.GetFileNameWithoutExtension(archivo.FileName);
            using (var reader = new BinaryReader(archivo.OpenReadStream()))
            {
                using (var streamWriter = new FileStream(raiz+"/Upload/"+ nombre+".zigzag", FileMode.OpenOrCreate))
                {
                    using (var writer = new BinaryWriter(streamWriter))
                    {
                        var olas = (2 * niveles) - 2;
                        var tamaño = (float)reader.BaseStream.Length / (float)olas;
                        var olasCan = tamaño % 1 <= 0.5 ? Math.Round(tamaño) + 1 : Math.Round(tamaño);
                        olasCan = Convert.ToInt32(olasCan);

                        var posicion = 0;
                        var nivelesC = 0;

                        var texto = new List<byte>[niveles];

                        for (int i = 0; i < niveles; i++)
                        {
                            texto[i] = new List<byte>();
                        }

                        var vff = 100000;
                        var bvff = new byte[vff];

                        while (reader.BaseStream.Position != reader.BaseStream.Length)
                        {
                            bvff = reader.ReadBytes(vff);
                            foreach (var caracter in bvff)
                            {
                                if (posicion == 0 || posicion % olas == 0)
                                {
                                    texto[0].Add(caracter);
                                    nivelesC = 0;
                                }
                                else if (posicion % olas == niveles - 1)
                                {
                                    texto[niveles - 1].Add(caracter);
                                    nivelesC = niveles - 1;
                                }
                                else if (posicion % olas < niveles - 1)
                                {
                                    nivelesC++;
                                    texto[nivelesC].Add(caracter);
                                }
                                else if (posicion % olas > niveles - 1)
                                {
                                    nivelesC--;
                                    texto[nivelesC].Add(caracter);
                                }
                                posicion++;
                            }
                        }

                        for (int i = 0; i < niveles; i++)
                        {
                            var cantIteracion = i == 0 || i == niveles - 1 ? olasCan : olasCan * 2;
                            var inicio = texto[i].Count();
                            for (int j = inicio; j < cantIteracion; j++)
                            {
                                texto[i].Add((byte)0);
                            }
                            writer.Write(texto[i].ToArray());
                        }
                    }
                }
            }
        }

        
        public  void Decifrar(IFormFile archivo, int niveles, string raiz)
        {
            string nombre = Path.GetFileNameWithoutExtension(archivo.FileName);
            using (var reader = new BinaryReader(archivo.OpenReadStream()))
            {
                using (var streamWriter = new FileStream(raiz + "/Upload/" + nombre + ".txt", FileMode.OpenOrCreate))
                {
                    using (var writer = new BinaryWriter(streamWriter))
                    {
                        var olas = (2 * niveles) - 2;
                        var olasCant = Convert.ToInt32(reader.BaseStream.Length) / olas;
                        var medios = (Convert.ToInt32(reader.BaseStream.Length) - (2 * olasCant)) / (niveles - 2);

                        var pos = 0;
                        var contNivel = 0;
                        var contIntermedio = 0;

                        var mensaje = new Queue<byte>[niveles];

                        for (int i = 0; i < niveles; i++)
                        {
                            mensaje[i] = new Queue<byte>();
                        }

                        var bufferLength = 100000;
                        var byteBuffer = new byte[bufferLength];

                        while (reader.BaseStream.Position != reader.BaseStream.Length)
                        {
                            byteBuffer = reader.ReadBytes(bufferLength);
                            foreach (var caracter in byteBuffer)
                            {
                                if (contNivel == niveles - 1)
                                {
                                    mensaje[contNivel].Enqueue(caracter);
                                }
                                else
                                {
                                    if (pos < olasCant)
                                    {
                                        mensaje[0].Enqueue(caracter);
                                    }
                                    else if (pos == olasCant)
                                    {
                                        contNivel++;
                                        mensaje[contNivel].Enqueue(caracter);
                                        contIntermedio = 1;
                                    }
                                    else if (contIntermedio < medios)
                                    {
                                        mensaje[contNivel].Enqueue(caracter);
                                        contIntermedio++;
                                    }
                                    else
                                    {
                                        contNivel++;
                                        mensaje[contNivel].Enqueue(caracter);
                                        contIntermedio = 1;
                                    }
                                    pos++;
                                }
                            }
                        }

                        contNivel = 0;
                        var direccion = true;
                        while (mensaje[1].Count() != 0 || (niveles == 2 && mensaje[1].Count() != 0))
                        {
                            if (contNivel == 0)
                            {
                                writer.Write(mensaje[contNivel].Dequeue());
                                contNivel = 1;
                                direccion = true;
                            }
                            else if (contNivel < niveles - 1 && direccion)
                            {
                                writer.Write(mensaje[contNivel].Dequeue());
                                contNivel++;
                            }
                            else if (contNivel > 0 && !direccion)
                            {
                                writer.Write(mensaje[contNivel].Dequeue());
                                contNivel--;
                            }
                            else if (contNivel == niveles - 1)
                            {
                                writer.Write(mensaje[contNivel].Dequeue());
                                contNivel = niveles - 2;
                                direccion = false;
                            }
                        }
                    }
                }
            }
        }

    }
}