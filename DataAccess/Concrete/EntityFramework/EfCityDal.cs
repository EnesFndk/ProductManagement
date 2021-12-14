using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCityDal : EfRepositoryBase<City>, ICityDal
    {
        public EfCityDal(XDbContext context) : base(context)
        {
        }

        public List<City> GetListWithCountry()
        {
            return _context.Cities.Include(q => q.Country).ToList();
        }
    }
}
