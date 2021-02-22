using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        //base:Result sınıfını temsil etmektedir.
        public DataResult(T data, bool success, string message)
            :base(success,message)
        {
            Data = data;
        }
        //mesaj göndermek istemiyorum:)
        public DataResult(T data,bool success)
            :base(success)
        {
            Data = data;
        }


        public T Data { get; }
    }
}
