using Business.Concrete;
using DataAccess.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())

            {

                Console.WriteLine("Car of Description: "+car.Description);
                Console.WriteLine("Car of Id: "+car.Id);
                Console.WriteLine("Car of BrandId: "+car.BrandId);
                Console.WriteLine("Car of ColorId: "+car.ColorId);
                Console.WriteLine("************************************");

            }
        }
        
    }
}
