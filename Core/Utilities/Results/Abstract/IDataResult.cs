using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Abstract
{
    //bu  interface: mesaj, işlem sonucunun yanında 
    //data da içermesini istenen işlemlerde kullanılır
   public  interface IDataResult<T>:IResult
    {
        T Data { get; }

    }
}
