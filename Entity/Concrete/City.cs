using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class City : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
    }
}
