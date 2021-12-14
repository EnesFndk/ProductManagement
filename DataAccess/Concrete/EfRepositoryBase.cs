using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfRepositoryBase<T> : IGenericDal<T> where T : class, IEntity
    {
        protected readonly XDbContext _context;
        public EfRepositoryBase(XDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
            //var deletedEntity = _context.Entry(entity);
            //deletedEntity.State = EntityState.Deleted;
            //_context.SaveChanges();
        }

        public void DeleteSelected(List<T> entities)
        {
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }


        public List<T> GetAllList()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Where(filter).ToList();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
