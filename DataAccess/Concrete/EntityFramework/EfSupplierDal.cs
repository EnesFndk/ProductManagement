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
    public class EfSupplierDal : EfRepositoryBase<Supplier>, ISupplierDal
    {
        public EfSupplierDal(XDbContext context) : base(context)
        {
           
        }

        public List<Supplier> GetListWithCity()
        {
            return _context.Suppliers.Include(q => q.City).ToList();
        }
    }
}
