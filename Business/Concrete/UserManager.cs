using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public void Delete(int id)
        {
            var entity = _userDal.GetById(id);
            _userDal.Delete(entity);
        }
        public void Update(User user)
        {
            _userDal.Update(user);
        }

        public User GetById(int id)
        {
            return _userDal.GetById(id);
        }

        public List<User> GetList()
        {
            return _userDal.GetAllList();
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(e => e.Mail == email);
        }

        
    }
}
