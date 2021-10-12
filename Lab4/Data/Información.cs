using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4.Data
{
    public class Información : InfoArch<int>
    {
        public IFormFile file { get; set; }
        public int TamañoCarriles { get; set; }
        public string NuevoNombre { get; set; }
        public string Palabra { get; set; }
        public int Tamaño { get; set; }
        IFormFile InfoArch<int>.ArchivoCargado { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
