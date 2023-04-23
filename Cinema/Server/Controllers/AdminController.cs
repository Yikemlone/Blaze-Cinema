using Cinema.DataAccess.Services.UnitOfWorkServices;
using Cinema.Models.Models;
using Cinema.Shared;
using Cinema.Shared.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Server.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;

        public AdminController(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }

        [HttpPost]
        [Route("create")]
        public async Task CreateMovie([FromBody] MovieDTO movie)
        {
            var movieID = await _unitOfWork.AdminService.CreateMovieAsync(movie);

            // Use that ID to rename the file, then try and save it to the public folder
            

            //uploadResult.StoredFileName = trustedFileNameForFileStorage;
            //uploadResult.ContentType = file.ContentType;
            //uploadResults.Add(uploadResult);
        }

        [HttpPost]
        [Route("update")]
        public async Task UpdateMovie([FromBody] MovieDTO movie)
        {
            await _unitOfWork.AdminService.UpdateMovieAsync(movie);
            await _unitOfWork.SaveAsync();
        }

        [HttpPost]
        [Route("delete/{movieID}")]
        public async Task DeleteMovie(int movieID)
        {
            await _unitOfWork.AdminService.DeleteMovieAsync(movieID);
            await _unitOfWork.SaveAsync();
        }

        [HttpPost]
        [Route("file/create")]
        public async Task UploadFile(List<IFormFile> files) 
        {
            //var uploadResult = new UploadResult();
            //string trustedFileNameForFileStorage;
            //var untrustedFileName = file.FileName;
            //uploadResult.FileName = untrustedFileName;
            ////trustedFileNameForFileStorage = movieID + ".jpg";

            //Console.WriteLine(_env.WebRootPath);

            //var path = Path.Combine(_env.WebRootPath, "images", untrustedFileName);

            //await using FileStream fs = new(path, FileMode.Create);
            //await file.CopyToAsync(fs);



            foreach (var file in files)
            {
                var uploadResult = new UploadResult();
                string trustedFileNameForFileStorage;
                var untrustedFileName = file.FileName + ".jpg";
                var path = Path.Combine(_env.ContentRootPath, "images", untrustedFileName);

                await using FileStream fs = new(path, FileMode.Create);
                await file.CopyToAsync(fs);
            }
        }
    }
}
