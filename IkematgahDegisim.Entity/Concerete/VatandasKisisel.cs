using IkematgahDegisim.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Entity.Concerete
{
    public class VatandasKisisel:IEntity
    {
        public int Id { get; set; }
        public string evAdres { get; set; }
        public string email { get; set; }
        public string ceptelefonNumarasi { get; set; }
        public Vatandas vatandas { get; set; }
    }
}
