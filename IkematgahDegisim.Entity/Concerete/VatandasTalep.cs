using IkematgahDegisim.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Entity.Concerete
{
    public class VatandasTalep:IEntity
    {
        public int Id { get; set; }

        public int talepId { get; set; }

        public Vatandas vatandas { get; set; }

        public IEnumerable<Talep> talepler { get; set; }
    }
}
