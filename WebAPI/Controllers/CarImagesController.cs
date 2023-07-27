using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using WebAPI.Models;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController:ControllerBase
    {
        ICarImageService _carImageService;
        public static IWebHostEnvironment _webHostEnvironment;
        public string _myUniqueFileName = string.Format(@"{0}.png", Guid.NewGuid());
        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
            
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(CarImages carImages) 
        {
            carImages.Date = DateTime.Now;
            var result = _carImageService.Add(carImages);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("upload")]
        public IResult UploadImage([FromForm] CarImageModel objectFile)
        {
            try
            {
               
                if (objectFile.files.Length>0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\Images\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path+_myUniqueFileName))
                    {
                        
                        objectFile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return new SuccessResult();
                    }

                }
                else
                {
                    return new SuccessResult();
                }
            }
            catch (Exception ex)
            {

                return new SuccessResult(ex.Message);
            }
        }
        
        


    }
    
}
