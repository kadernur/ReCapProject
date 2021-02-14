using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //Burda generic class yapısını kullandım. ve bu classın IEntity'i implemente eden bir class ve newlenemez olması şartını yazdım.
    
   public  interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //Expression yapısıyla birlikte filtreleme yapılacak linq yapısına ortam hazırladım diyebiliriz.
        List<T> GetAll(Expression<Func<T,bool>> filter=null);

        //tek bir data getirmemi sağlayan method.
        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);

        void Update(T entity);
        void Delete(T entity);




    }
}
