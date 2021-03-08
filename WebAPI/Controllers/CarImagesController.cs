using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        public static ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById([FromForm(Name ="Id")] int id)
        {
            var result = _carImageService.GetImageById(id);
            if(result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }

        [HttpGet("getimagesbycarid")]
        public IActionResult GetImagesByCarId([FromForm(Name = "CarId")] int carId)
        {
            var result = _carImageService.GetImagesByCarId(carId);

            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }



        [HttpPost("add")]
        public IActionResult Add([FromForm(Name="Image")]

        IFormFile file, [FromForm] CarImage carImage)
        {

            var result = _carImageService.Add(file, carImage);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = "Image")] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Update(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("delete")]
        public IActionResult Delete([FromForm(Name = "Id")] int id)
        {
            var carImage = _carImageService.GetImageById(id).Data;
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }





    }
}