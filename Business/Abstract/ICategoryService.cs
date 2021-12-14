using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        void Add(Category category);
        void Delete(int id);
        void Update(Category category);
        List<Category> GetList();
        Category GetById(int id);
        //List<Category> GetByProductId(int id);
        //List<Product> GetListByProduct(Product product);
    }
}
