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
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDatabaseContext context=new ReCapDatabaseContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId

                             select new CarDetailDto 
                             { 
                                
                                 ColorName=color.ColorName,
                                 BrandName=brand.BrandName,
                                 DailyPrice=Convert.ToDouble(car.DailyPrice)
                             
                             
                             
                             };
                return result.ToList();


            }

        }
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