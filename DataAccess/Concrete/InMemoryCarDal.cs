using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        //oracle,Sql Server gibi veri tabanlarını simüle ediyor.
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,
                ModelYear="2011",DailyPrice=250,
                Descriptions="Opel Corsa Dizel Otomatik"},

                new Car{CarId=2,BrandId=2,ColorId=2,
                ModelYear="2009",DailyPrice=520,
                Descriptions="Wolksvagen Passat Dizel Otomatik"},

                new Car {CarId=3,BrandId=3,ColorId=3,
                ModelYear="2015",DailyPrice=450,
                Descriptions="Audi A3 Dizel Otomatik"},

               new Car{CarId=4,BrandId=4,ColorId=4,
               ModelYear="2013",DailyPrice=85,
               Descriptions="Fiat Doblo"},


            };

        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            //LINQ ile

            Car carToDelete;
            carToDelete = _cars.SingleOrDefault(c =>c.CarId==car.CarId);
            _cars.Remove(carToDelete);
                           
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<CarDetailDto> GetAllCarDetailsByFilter(CarDetailFilterDto filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c =>c.CarId==id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c=> c.CarId==car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Descriptions = car.Descriptions;


        }
    }
}
