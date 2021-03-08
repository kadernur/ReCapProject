using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        public ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitExceeded(carImage.CarId));
            if(result!=null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.AddAsync(formFile);
            carImage.CarImageDate = DateTime.Today;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.Added);



        }

       

        public IResult Delete( CarImage carImage)
        {
            var oldPath =$@"{ Environment.CurrentDirectory}\wwwroot
                {_carImageDal.Get(c=>c.Id==carImage.Id).ImagePath }";

            FileHelper.DeleteAsync(oldPath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.Deleted);

            
            
            
        }


        public IDataResult<List<CarImage>> GetAll()
        {

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());


        }




    

        public IDataResult<CarImage> GetImageById(int id)
        {

            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));

        }



        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            var result = _carImageDal.GetAll(c => c.CarId == id);
            if (result.Count == 0)
            {
                var defaultImage = DefaultImage(id);
                return new SuccessDataResult<List<CarImage>>(defaultImage.Data);
            }

            return new SuccessDataResult<List<CarImage>>(result);


        }

        private IDataResult<List<CarImage>> DefaultImage(int id)
        {
            List<CarImage> carImages = new List<CarImage>
            {
                new CarImage
                {
                    CarId = id, ImagePath = ($@"{Environment.CurrentDirectory}\wwwroot\Images\default.jpg")
                }
            };
            return new SuccessDataResult<List<CarImage>>(carImages);
        }



        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            var oldPath = $@"{Environment.CurrentDirectory}\wwwroot{_carImageDal.Get(c => c.Id == carImage.Id).ImagePath}";
            carImage.ImagePath = FileHelper.UpdateAsync(oldPath, formFile);

            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.Updated);



        }




        private IResult CheckIfCarImageLimitExceeded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if(result>=5)
            {
                return new ErrorResult(Messages.CarOfImageLimitExceeded);
            }
            return new SuccessResult();
        }
    }
}
