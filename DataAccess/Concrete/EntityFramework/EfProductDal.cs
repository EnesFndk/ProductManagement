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
    public class EfProductDal : EfRepositoryBase<Product>, IProductDal
    {
        public EfProductDal(XDbContext context) : base(context)
        {
        }
        

        public List<Product> GetListWithBrand()
        {
            return _context.Products.Include(q => q.Brand).ToList();
        }
    }
}
