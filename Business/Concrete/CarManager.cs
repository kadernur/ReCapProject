using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
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





          // Sisteme yeni araba eklendiğinde aşağıdaki kuralları çalıştırınız.

          //Araba ismi minimum 2 karakter olmalıdır
 
         //Araba günlük fiyatı 0'dan büyük olmalıdır.
        public void Add(Car car)
        {
           /* if(car.DailyPrice>=0 || car.Descriptions.Length<2)
            {
                throw new NotImplementedException("Ücret 0'dan büyük ve Açıklama iki karakterden oluşmalı");

            }*/
            _carDal.Add(car);

        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        
        public List<Car> GetCarsByColorId (int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }
        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public List<Car> GetById(int id)
        {
            return _carDal.GetAll(p => p.CarId == id);
        }

        Car ICarService.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
