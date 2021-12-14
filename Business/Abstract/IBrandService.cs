using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        void Add(Brand brand);
        void Delete(int id);
        void Update(Brand brand);
        List<Brand> GetList();
        Brand GetById(int id);
        //List<Brand> GetByProductId(int id);
        //List<Product> GetListByProduct(Product product);
    }
}
