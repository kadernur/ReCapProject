using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetAllCarDetailsByFilter(CarDetailFilterDto filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             // join carImage in context.CarImages on car.CarId equals carImage.CarId
                             select new CarDetailDto() {
                                 CarId = car.CarId,
                                 Images =
                                 (from i in context.CarImages where i.CarId == car.CarId select i.ImagePath).ToList(),
                                 Description = car.Descriptions,
                                 BrandId = brand.BrandId,
                                 BrandName = brand.BrandName,
                                 ColorId = color.ColorId,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,


                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }



        public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             where c.ColorId == colorId
                             select new CarDetailDto {
                                 CarId = c.CarId,
                                 BrandName = b.BrandName,
                                 ModelYear = c.ModelYear,
                                 ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Descriptions = c.Descriptions,
                                 ImagePath = (from a in context.CarImages where a.CarId == c.CarId select a.ImagePath).FirstOrDefault()

                             };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             where c.BrandId == brandId
                             select new CarDetailDto {
                                 CarId = c.CarId,
                                 BrandName = b.BrandName,
                                 ModelYear = c.ModelYear,
                                 ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Descriptions = c.Descriptions,
                                 ImagePath = (from a in context.CarImages where a.CarId == c.CarId select a.ImagePath).FirstOrDefault()

                             };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandAndColor(int brandId, int colorId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             where c.BrandId == brandId
                             where c.ColorId == colorId
                             select new CarDetailDto {
                                 CarId = c.CarId,
                                 BrandName = b.BrandName,
                                 ModelYear = c.ModelYear,
                                 ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Descriptions = c.Descriptions,
                                 ImagePath = (from a in context.CarImages where a.CarId == c.CarId select a.ImagePath).FirstOrDefault()

                             };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsById(int carId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             where c.CarId == carId
                             select new CarDetailDto {
                                 CarId = c.CarId,
                                 BrandName = b.BrandName,
                                 ModelYear = c.ModelYear,
                                 ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Descriptions = c.Descriptions,
                                 ImagePath = (from a in context.CarImages where a.CarId == c.CarId select a.ImagePath).FirstOrDefault()
                             };

                return result.ToList();
            }
        }
        //public List<CarDetailDto> GetAllCarDetailsByFilter(CarDetailFilterDto filterDto)
        //{
        //    using (ReCapDatabaseContext context = new ReCapDatabaseContext())
        //    {
        //        var filterExpression =GetAllCarDetailsByFilter (filterDto);
        //        var result = from car in filterExpression == null ? context.Cars : context.Cars.Where(filterExpression)
        //                     join color in context.Colors on car.ColorId equals color.ColorId
        //                     join brand in context.Brands on car.BrandId equals brand.BrandId
        //                     join carImage in context.CarImages on car.CarId equals carImage.CarId
        //                     select new CarDetailDto {
        //                         CarId = car.CarId,
        //                         BrandId = brand.BrandId,
        //                         ColorId = color.ColorId,
        //                         Images =
        //                    (from i in context.CarImages where i.CarId == car.CarId select i.ImagePath).ToList(),
        //                         ModelYear = car.ModelYear,
        //                         BrandName = brand.BrandName,
        //                         Description = car.Description,
        //                         ColorName = color.ColorName,
        //                         DailyPrice = car.DailyPrice
        //                     };
        //        return result.ToList(); // tolist yapmadan query'e dönüştürüp verileri çekmez.

        //    }
        //}
    }
}

//CarName, BrandName, ColorName, DailyPrice
/*
*select CarName, BrandName, ColorName, DailyPrice from Cars
inner join Brands on Cars.BrandId = Brands.BrandId
inner join Colors on cars.ColorId = Colors.ColorId
*
*
 *using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                    join c in context.Categories 
                    on p.CategoryId equals c.CategoryId
                    select new ProductDetailDTO
                    {ProductId = p.ProductId, ProductName = p.ProductName, CategoryName = c.CategoryName, UnitsInStock = p.UnitsInStock};
                return result.ToList();
            }
 *
 */