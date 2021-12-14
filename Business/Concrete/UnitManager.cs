using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UnitManager:IUnitService
    {
        IUnitDal _unitDal;

        public UnitManager(IUnitDal unitDal)
        {
            _unitDal = unitDal;
        }
        public void Add(Unit unit)
        {
            _unitDal.Add(unit);
        }

        public void Delete(int id)
        {
            var entity = _unitDal.GetById(id);
            _unitDal.Delete(entity);
        }
        public void Update(Unit unit)
        {
            _unitDal.Update(unit);
        }

        public Unit GetById(int id)
        {
            return _unitDal.GetById(id);
        }

        public List<Unit> GetList()
        {
            return _unitDal.GetAllList();
        }

        
    }
}
