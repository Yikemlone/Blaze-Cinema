﻿using Cinema.DataAccess.Services.UnitOfWorkServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Server.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class FileController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public FileController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        [Route("{filename}")]
        public async Task<IActionResult> GetImage(string filename)
        {
            var path = Path.Combine(_env.ContentRootPath, "images", $"{filename}.jpg");
            byte[] imageBytes = System.IO.File.ReadAllBytes(path);

            return new FileContentResult(imageBytes, "image/jpeg");
        }

        [HttpPost]
        [Authorize(Policy = ("IsAdmin"))]
        [Route("create")]
        public async Task UploadFile(List<IFormFile> files)
        {
            foreach (var file in files)
            {
                var path = Path.Combine(_env.ContentRootPath, "images", file.FileName);
                await using FileStream fs = new(path, FileMode.Create);
                await file.CopyToAsync(fs);
            }
        }

        [HttpPost]
        [Authorize(Policy = ("IsAdmin"))]
        [Route("delete")]
        public async Task DeleteImage([FromBody] int filename)
        {
            var path = Path.Combine(_env.ContentRootPath, "images", $"{filename}.jpg");
            System.IO.File.Delete(path);
        }
    }
}
