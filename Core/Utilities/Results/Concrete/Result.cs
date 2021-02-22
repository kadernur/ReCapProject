using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        //base constructor yapısını kullandım.
        //mesaj ve başarılı olup olmadığını döndürmek istiyorum.

        public Result(bool success,string message):this(success)
        {
            Message = message;
        }
        //mesaj döndürmek istemiyorum.
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }
        public string Message { get; }
    }
}
