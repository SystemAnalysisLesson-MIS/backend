
using IkematgahDegisim.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Entity.Concerete
{
   public class Ikematgah:IEntity
    {
        public int Id { get; set; }
        public string ikematgahAdres { get; set; }
        public IEnumerable<Vatandas> vatandaslar { get; set; }
    }
}
