using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
  public  class SuccessResult:Result
    {
        //default olarak true verip mesaj yazcam
        //sadece mesaj vercem
        //base:Result sınıfını temsil eder.
        public SuccessResult(string message) : base(true, message)
        {

        }

        //mesaj vermek istemiyorsam
        public SuccessResult():base(true)
        {

        }

    }
}
