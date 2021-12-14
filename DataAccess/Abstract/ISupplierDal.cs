using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ISupplierDal:IGenericDal<Supplier>
    {
        public List<Supplier> GetListWithCity();
    }
}
