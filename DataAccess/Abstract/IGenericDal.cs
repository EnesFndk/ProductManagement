using Entity.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IGenericDal<T> where T: class, IEntity
    {
        void Add(T entity);
        void Delete(T entity);
        void DeleteSelected(List<T> entities);
        void Update(T entity);
        List<T> GetAllList();
        T Get(Expression<Func<T, bool>> filter);
        T GetById(int id);
        List<T> GetListAll(Expression<Func<T, bool>> filter);
    }
}
