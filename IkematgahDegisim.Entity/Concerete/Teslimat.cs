
using IkematgahDegisim.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Entity.Concerete
{
    public class Teslimat:IEntity
    {
        public int Id { get; set; }
        public int teslimatToken { get; set; }

        public VatandasTeslimat vatandasTeslimat { get; set; }
        
    }
}
