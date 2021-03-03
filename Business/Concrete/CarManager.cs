using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
   public  class CarManager : ICarService

    {
        ICarDal _carDal;//DataAccess katmanına erişimi sağlar.


        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }





       
        public IResult Add(Car car)
        {
          
          
            _carDal.Add(car);

            return new SuccessResult(Messages.Added);

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.Listed);
        }

        
        public IDataResult<List<Car>> GetCarsByColorId (int id)
        { 
           return  new SuccessDataResult<List<Car>>( _carDal.GetAll(c => c.ColorId == id).ToList(),Messages.Listed);
        }
        public IDataResult< List<Car> >GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id).ToList(),Messages.Listed);

        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }

        public  IDataResult<Car> GetById(int id)
        {
            return new  SuccessDataResult<Car>(_carDal.Get(p => p.CarId == id),Messages.Listed);
        }

        
    }
}
