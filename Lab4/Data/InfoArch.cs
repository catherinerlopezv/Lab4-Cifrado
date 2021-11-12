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
        T key { get; set; }
        string cipher { get; set; }
        string word { get; set; }
    }
}
