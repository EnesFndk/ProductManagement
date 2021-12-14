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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            _brandDal.Add(brand);
        }

        public void Delete(int id)
        {
            var entity = _brandDal.GetById(id);
            _brandDal.Delete(entity);
        }
        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }

        public Brand GetById(int id)
        {
            return _brandDal.GetById(id);
        }

        public List<Brand> GetList()
        {
            return _brandDal.GetAllList();
        }

       
    }
}
