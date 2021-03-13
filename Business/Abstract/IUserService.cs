﻿using Core.Utilities.Results.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public   interface IUserService
    {
        IDataResult<List<User>> GetAll();

        IDataResult<User> GetById(int id);

        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);

        List<OperationClaim> GetClaims(User user);
       
        User GetByMail(string email);


    }
}
