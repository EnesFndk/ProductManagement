﻿using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        void Delete(int id);
        void Update(User user);
        List<User> GetList();
        User GetById(int id);
        User GetByMail(string email);
    }
}
