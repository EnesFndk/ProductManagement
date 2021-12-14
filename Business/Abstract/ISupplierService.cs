using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISupplierService
    {
        void Add(Supplier supplier);
        void Delete(int id);
        void Update(Supplier supplier);
        List<Supplier> GetList();
        Supplier GetById(int id);
        //List<Supplier> GetByCityId(int id);
    }
}
