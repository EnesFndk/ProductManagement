using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        void Add(Product product);
        void Delete(int id);
        void Update(Product product);
        List<Product> GetList();
        Product GetById(int id);
        //List<Product> GetByBrandId(int id);
        //List<Brand> GetByProductId(int id);
        //List<Category> GetByProductId(int id);
    }
}
