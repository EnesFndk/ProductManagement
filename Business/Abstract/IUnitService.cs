using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUnitService
    {
        void Add(Unit unit);
        void Delete(int id);
        void Update(Unit unit);
        List<Unit> GetList();
        Unit GetById(int id);
        //List<Unit> GetByProductId(int id);
        //List<Product> GetListByProduct(Product product);
    }
}
