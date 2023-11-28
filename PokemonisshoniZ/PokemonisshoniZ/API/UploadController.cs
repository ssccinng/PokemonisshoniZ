using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonisshoniZ.API
{
    [Route("api/[controller]")]
    [ApiController]

    [DisableRequestSizeLimit]
    //[Route("api/[controller]")]
    //[ApiController]

    //[Authorize]
    public partial class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public UploadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost("/upload/single")]
        public IActionResult Single(IFormFile file)
        {
            try
            {
                // Put your code here
                //UploadFile(file);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("/upload/avatar")]
        public IActionResult Avatar(IFormFile file)
        {

            try
            {
                if (file.Length > 1024 * 512)
                    throw new Exception("文件太大了! 最大为512kb");
                var uploadPath = _environment.WebRootPath + @"/Avatar";
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";



                using (var stream = new FileStream(Path.Combine(_environment.WebRootPath + @"/Avatar", fileName), FileMode.Create))
                {
                    // Save the file
                    file.CopyTo(stream);

                    // Return the URL of the file
                    var url = Url.Content($"~/Avatar/{fileName}");

                    return Ok(new { Url = url });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            //try
            //{
            //    // Put your code here
            //    UploadFile(file);
            //    return StatusCode(200);
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, ex.Message);
            //}
        }



        [HttpPost("/upload/teamimage")]
        public IActionResult TeamImage(IFormFile files)
        {

            try
            {
                if (files.Length > 1024 * 1024)
                    throw new Exception("文件太大了! 最大为1mb");
                var uploadPath = _environment.WebRootPath + @"/Upload";
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(files.FileName)}";



                using var stream = new MemoryStream() ;
                using var filestream = new FileStream(Path.Combine(uploadPath, fileName), FileMode.Create) ;

                    byte[] aa = new byte[files.Length];

                    // Save the file
                    files.CopyTo(stream);
                    var fileBytes = stream.ToArray();
                filestream.Write(fileBytes, 0, (int)files.Length);

                    // Return the URL of the file
                    var url = Url.Content($"~/Upload/{fileName}");

                    return Ok(new { Data = fileBytes, Url = url });
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            //try
            //{
            //    // Put your code here
            //    UploadFile(file);
            //    return StatusCode(200);
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, ex.Message);
            //}
        }

        [HttpPost("/upload/image")]
        public IActionResult Image([FromBody] IFormFile file)
        {

            try
            {
                if (file.Length > 1024 * 512)
                    throw new Exception("文件太大了! 最大为512kb");
                var uploadPath = _environment.WebRootPath + @"/Upload";
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";



                using (var stream = new FileStream(Path.Combine(_environment.WebRootPath + @"/Upload", fileName), FileMode.Create))
                {
                    // Save the file
                    file.CopyTo(stream);

                    // Return the URL of the file
                    var url = Url.Content($"~/Upload/{fileName}");

                    return Ok(new { Url = url });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            //try
            //{
            //    // Put your code here
            //    UploadFile(file);
            //    return StatusCode(200);
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, ex.Message);
            //}
        }

        public async Task UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var imagePath = @"\Upload";
                var uploadPath = _environment.WebRootPath + imagePath;
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                var fullPath = Path.Combine(uploadPath, file.FileName);

                using (FileStream fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
        }

    }


}
