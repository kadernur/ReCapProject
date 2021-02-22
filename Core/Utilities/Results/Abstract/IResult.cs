using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Abstract
{
   public interface IResult
    {
        //Yaptığım işlev başarılı mı değilmi onu test ediyorum.
        bool Success { get; }

        // ekranda mesaj göstermek istiyorsam.

        string Message { get; }

    }
}
