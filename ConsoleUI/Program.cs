using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();

            //ColorTest();
            // DtoTest();

            CarCrudTest();


            // ColorCrudTest();
            //BrandCrudTest();

        }

        private static void BrandCrudTest()
        {
            BrandManager _brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("Tüm markalarımız:");
            foreach (var brand in _brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }

            Console.WriteLine("İstediğiniz marka:");
            Console.WriteLine(_brandManager.GetById(1).Data.BrandName);

            Console.WriteLine("Marka eklendi.");
            _brandManager.Add(new Brand() { BrandName = "Hyundai" });

            Console.WriteLine("Marka güncellendi");
            _brandManager.Update(new Brand() { BrandId = 5, BrandName = "Aston Martin" });

            Console.WriteLine("Marka silindi");
            _brandManager.Delete(new Brand() { BrandId = 5 });
        }

        private static void ColorCrudTest()
        {
            ColorManager _colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine("Tüm renklerimiz:");
            foreach (var color in _colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine("İstediğiniz renk:");
            Console.WriteLine(_colorManager.GetById(1).Data.ColorName);

            Console.WriteLine("renk eklendi.");
            _colorManager.Add(new Color() { ColorName = "Turuncu" });

            Console.WriteLine("renk güncellendi");
            _colorManager.Update(new Color() { ColorId = 6, ColorName = "Fuşya" });

            Console.WriteLine("renk silindi");
            _colorManager.Delete(new Color() { ColorId = 6 });
        }

        private static void CarCrudTest()
        {
            CarManager _carManager = new CarManager(new EfCarDal());
            Console.WriteLine("Tüm Araçlarımız: ");
            foreach (var car in _carManager.GetAll().Data)
            {
                Console.WriteLine(car.Descriptions);
            }

            Console.WriteLine("\n \n " + "İstediğimiz araç :");
            Console.WriteLine(_carManager.GetById(1).Data);

            Console.WriteLine("Aracınız Eklendi: ");
            _carManager.Add(new Car() {
                BrandId = 3,
                ColorId = 4,
                DailyPrice = 2,
                Descriptions = "Fiat Linea",
                ModelYear = "2012"


            });
            Console.WriteLine("Aracınız Silindi");
            _carManager.Delete(new Car() { CarId = 21 });
        }

        private static void DtoTest()
        {
            EfCarDal _efCarDal = new EfCarDal();
            foreach (var car in _efCarDal.GetCarDetails())
            {
                Console.WriteLine(
                    car.CarName + "/" +
                    car.ColorName + "/" +
                    car.BrandName + "/" +
                    car.DailyPrice + "TL");

            }
            Console.Read();
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetAll().Data)

            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void CarTest()
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

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarId + "     " + car.ModelYear + "     " + car.DailyPrice + "        " + car.Descriptions);
            }
            Console.WriteLine("****************************");

            foreach (var car in carManager.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine(car.Descriptions);
            }
            Console.WriteLine("****************************");

            foreach (var car in carManager.GetCarsByColorId(3).Data)
            {
                Console.WriteLine(car.Descriptions);
            }
            Console.WriteLine("****************************");

            carManager.Add(new Car {
                CarId = 7,
                BrandId = 4,
                ColorId = 1,
                DailyPrice = 500,
                Descriptions = "Tesle Model 3",
                ModelYear = "2015"
            });

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarId + "  " + car.ModelYear + "   " + car.DailyPrice + "   " + car.Descriptions);
            }
        }
    }
}
