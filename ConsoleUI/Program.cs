using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            /*  foreach (var car in carManager.GetAll())

              {

                  Console.WriteLine("Car of Description: "+car.Description);
                  Console.WriteLine("Car of Id: "+car.Id);
                  Console.WriteLine("Car of BrandId: "+car.BrandId);
                  Console.WriteLine("Car of ColorId: "+car.ColorId);
                  Console.WriteLine("************************************");

              }*/

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + "     "+ car.ModelYear +"     " +car.DailyPrice+"        "+car.Description);
            }
            Console.WriteLine("****************************");

            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("****************************");

            foreach (var car in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("****************************");

            carManager.Add(new Car
            {
                Id = 7,
                BrandId = 4,
                ColorId = 1,
                DailyPrice = 500,
                Description = "Tesle Model 3",
                ModelYear = 2015
            });

            foreach (var car  in carManager.GetAll())
            {
                Console.WriteLine(car.Id+"  "+car.ModelYear+"   "+car.DailyPrice+"   "+car.Description);
            }

        }
        
    }
}
