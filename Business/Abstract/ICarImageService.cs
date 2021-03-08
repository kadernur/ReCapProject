using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public  interface ICarImageService
    {
        IResult Add(IFormFile formFile, CarImage carImage);
        IResult Update(IFormFile formFile, CarImage carImage);
        IResult Delete( CarImage carImage);

        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetImagesByCarId(int id);
        IDataResult<CarImage> GetImageById(int id);
        



    }
}
