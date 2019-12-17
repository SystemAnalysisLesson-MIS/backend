
using IkematgahDegisim.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Entity.Concerete
{ 
    public class VatandasTeslimat:IEntity
    {
        public int Id { get; set; }

        public int teslimatId { get; set; }

        public Vatandas vatandas { get; set; }

        public IEnumerable<Teslimat> teslimatlar { get; set; }
    }
}
