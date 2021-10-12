using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lab4.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cifrado;
namespace Lab4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Api : ControllerBase
    {

        public static IWebHostEnvironment _environment;
        public Api(IWebHostEnvironment environment)
        {
            _environment = environment;

        }
        public class FileUploadAPI
        {
            public IFormFile file { get; set; }

        }

        [HttpPost("cipher/ZigZag")]
        public IActionResult postCipherZZ([FromForm]Información objFile)
        {

            try
            {
                if (objFile.file.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.file.FileName))
                    {
                        objFile.file.CopyTo(fileStream);
                        fileStream.Flush();
                        fileStream.Close();
                        string s = @_environment.WebRootPath;
                        //Implementacion imp = new Implementacion(fileStream.Name, s);
                        ZigZaOpg.Cifrado(fileStream.Name, s, objFile.TamañoCarriles);
                        MemoryStream enviar = new MemoryStream(System.IO.File.ReadAllBytes(_environment.WebRootPath +
                           "\\Upload\\" + Path.GetFileNameWithoutExtension(objFile.file.FileName) + ".ZigZag"));
                        return File(enviar, "text/plain", Path.GetFileNameWithoutExtension(objFile.file.FileName) + ".ZigZag");
                    }


                }
                else
                {
                    return StatusCode(500);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { name = "Internal Server Error", message = ex.Message });
            }



        }

        [HttpPost("decipher/ZigZag")]
        public IActionResult postDecipherZZ([FromForm]Información objFile)
        {

            try
            {
                if (objFile.file.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.file.FileName))
                    {
                        objFile.file.CopyTo(fileStream);
                        fileStream.Flush();
                        fileStream.Close();
                        string s = @_environment.WebRootPath;
                       
                        ZigZaOpg.Descifrado(fileStream.Name, s, objFile.TamañoCarriles);

                        MemoryStream enviar = new MemoryStream(System.IO.File.ReadAllBytes(_environment.WebRootPath +
                           "\\Upload\\" + Path.GetFileNameWithoutExtension(objFile.file.FileName) + ".txt"));
                        return File(enviar, "text/plain", Path.GetFileNameWithoutExtension(objFile.file.FileName) + ".txt");

                    }


                }
                else
                {
                    return StatusCode(500);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { name = "Internal Server Error", message = ex.Message });
            }
        }

        [HttpPost("cipher/Cesar")]
        public IActionResult postCipherCesar([FromForm]Información objFile)
        {
            try
            {
                if (objFile.file.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.file.FileName))
                    {
                        objFile.file.CopyTo(fileStream);
                        fileStream.Flush();
                        fileStream.Close();
                        string s = @_environment.WebRootPath;
                       
                        CesarOp.Cifrado(fileStream.Name, s, objFile.Palabra);

                        MemoryStream enviar = new MemoryStream(System.IO.File.ReadAllBytes(_environment.WebRootPath +
                           "\\Upload\\" + Path.GetFileNameWithoutExtension(objFile.file.FileName) + ".cesar"));
                        return File(enviar, "text/plain", Path.GetFileNameWithoutExtension(objFile.file.FileName) + ".cesar");

                    }


                }
                else
                {
                    return StatusCode(500);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { name = "Internal Server Error", message = ex.Message });
            }



        }

        [HttpPost("decipher/Cesar")]
        public IActionResult postDecipherCesar([FromForm]Información objFile)
        {

            try
            {
                if (objFile.file.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.file.FileName))
                    {
                        objFile.file.CopyTo(fileStream);
                        fileStream.Flush();
                        fileStream.Close();
                        string s = @_environment.WebRootPath;

                        CesarOp.Descifrado(fileStream.Name, s, objFile.Palabra);


                        MemoryStream enviar = new MemoryStream(System.IO.File.ReadAllBytes(_environment.WebRootPath +
                           "\\Upload\\" + Path.GetFileNameWithoutExtension(objFile.file.FileName) + ".txt"));
                        return File(enviar, "text/plain", Path.GetFileNameWithoutExtension(objFile.file.FileName) + ".txt");

                    }


                }
                else
                {
                    return StatusCode(500);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { name = "Internal Server Error", message = ex.Message });
            }



        }      

    }
}