using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUnitDal : EfRepositoryBase<Unit>, IUnitDal
    {
        public EfUnitDal(XDbContext context) : base(context)
        {
        }
    }
}
