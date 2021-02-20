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

            using (TContext reCapDatabaseCotext = new TContext())
            {
                var addedEntity = reCapDatabaseCotext.Entry(entity);
                addedEntity.State = EntityState.Added;
                reCapDatabaseCotext.SaveChanges();

            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext reCapDatabaseCotext = new TContext())
            {
                var deletedEntity = reCapDatabaseCotext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                reCapDatabaseCotext.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext reCapDatabaseCotext = new TContext())
            {
                //tek bir data getiren methodumuz.
                return reCapDatabaseCotext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            //filtre zorunluluğu yok, Filtre kullanmazsam bütün dataları liste halinde döndürür.

            using (TContext reCapDatabaseCotext = new TContext())
            {
                return filter == null
                    ? reCapDatabaseCotext.Set<TEntity>().ToList()
                    : reCapDatabaseCotext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext reCapDatabaseCotext = new TContext())
            {
                var updatedEntity = reCapDatabaseCotext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                reCapDatabaseCotext.SaveChanges();

            }
        }

    }
}
