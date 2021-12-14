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
    public class CountryManager:ICountryService
    {
        ICountryDal _countryDal;

        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }
        public void Add(Country country)
        {
            _countryDal.Add(country);
        }

        public void Delete(int id)
        {
            var entity = _countryDal.GetById(id);
            _countryDal.Delete(entity);
        }
        public void Update(Country country)
        {
            _countryDal.Update(country);
        }

        public Country GetById(int id)
        {
            return _countryDal.GetById(id);
        }

        public List<Country> GetList()
        {
            return _countryDal.GetAllList();
        }

        
    }
}
