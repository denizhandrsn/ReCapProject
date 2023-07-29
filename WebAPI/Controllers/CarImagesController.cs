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
        
        
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
            
            
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
        public IActionResult Add([FromForm] IFormFile file, [FromForm] CarImages carImages) 
        {
            var result = _carImageService.Add(file,carImages);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
    }
    
}
