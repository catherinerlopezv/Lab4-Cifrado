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
        public int key { get; set; }
        public string cipher { get; set; }
        public string word { get; set; }
        IFormFile InfoArch<int>.ArchivoCargado { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
