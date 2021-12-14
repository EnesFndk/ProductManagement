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
    public class CityManager:ICityService
    {
        ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }
        public void Add(City city)
        {
            _cityDal.Add(city);
        }

        public void Delete(int id)
        {
            var entity = _cityDal.GetById(id);
            _cityDal.Delete(entity);
        }
        public void Update(City city)
        {
            _cityDal.Update(city);
        }

        public City GetById(int id)
        {
            return _cityDal.GetById(id);
        }

        public List<City> GetList()
        {
            return _cityDal.GetListWithCountry();
        }

        
    }
}
