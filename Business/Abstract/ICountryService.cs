using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICountryService
    {
        void Add(Country country);
        void Delete(int id);
        void Update(Country country);
        List<Country> GetList();
        Country GetById(int id);
        //List<City> GetByCityId(int id);
    }
}
