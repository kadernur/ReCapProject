using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            //hem işimiz bittikten sonra gereksiz bellek harcamamak ve 
            //performans artışını sağlamak için using bloğunu kullandım.

            using (ReCapDatabaseCotext reCapDatabaseCotext=new ReCapDatabaseCotext())
            {
                var addedEntity = reCapDatabaseCotext.Entry(entity);
                addedEntity.State = EntityState.Added;
                reCapDatabaseCotext.SaveChanges();

            }
        }

        public void Delete(Car entity)
        {
            using (ReCapDatabaseCotext reCapDatabaseCotext=new ReCapDatabaseCotext())
            {
                var deletedEntity = reCapDatabaseCotext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                reCapDatabaseCotext.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapDatabaseCotext reCapDatabaseCotext=new ReCapDatabaseCotext())
            {
                //tek bir data getiren methodumuz.
                return reCapDatabaseCotext.Set<Car>().SingleOrDefault(filter);
            } 
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            //filtre zorunluluğu yok, Filtre kullanmazsam bütün dataları liste halinde döndürür.

            using (ReCapDatabaseCotext reCapDatabaseCotext=new ReCapDatabaseCotext())
            {
                return filter == null
                    ? reCapDatabaseCotext.Set<Car>().ToList()
                    : reCapDatabaseCotext.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (ReCapDatabaseCotext reCapDatabaseCotext=new ReCapDatabaseCotext())
            {
                var updatedEntity = reCapDatabaseCotext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                reCapDatabaseCotext.SaveChanges();

            }
        }
    }
}
