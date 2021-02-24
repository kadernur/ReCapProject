using Core.Abstract;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
   public  class EfEntityRepositoryBase<TEntity,TContext> :IEntityRepository<TEntity>
        where TEntity:class,IEntity,new()
        where TContext: DbContext,new()
    {
        public void Add(TEntity entity)
        {
            //hem işimiz bittikten sonra gereksiz bellek harcamamak ve 
            //performans artışını sağlamak için using bloğunu kullandım.

            using (TContext reCapDatabaseContext = new TContext())
            {
                var addedEntity = reCapDatabaseContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                reCapDatabaseContext.SaveChanges();

            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext reCapDatabaseContext = new TContext())
            {
                var deletedEntity = reCapDatabaseContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                reCapDatabaseContext.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext reCapDatabaseContext = new TContext())
            {
                //tek bir data getiren methodumuz.
                return reCapDatabaseContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            //filtre zorunluluğu yok, Filtre kullanmazsam bütün dataları liste halinde döndürür.

            using (TContext reCapDatabaseContext = new TContext())
            {
                return filter == null
                    ? reCapDatabaseContext.Set<TEntity>().ToList()
                    : reCapDatabaseContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext reCapDatabaseContext = new TContext())
            {
                var updatedEntity = reCapDatabaseContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                reCapDatabaseContext.SaveChanges();

            }
        }

    }
}
