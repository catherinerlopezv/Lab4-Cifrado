using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4.Data
{
    public interface InfoArch<T>
    {

        IFormFile ArchivoCargado { get; set; }
        T TamañoCarriles { get; set; }
        string NuevoNombre { get; set; }
        string Palabra { get; set; }
        int Tamaño { get; set; }
    }
}
