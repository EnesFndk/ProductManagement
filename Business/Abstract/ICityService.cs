using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICityService
    {
        void Add(City city);
        void Delete(int id);
        void Update(City city);
        List<City> GetList();
        City GetById(int id);
        //List<City> GetByCountryId(int id);
    }
}
