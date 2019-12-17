using IkematgahDegisim.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Entity.Concerete.Dtos.Vatandas
{
    public class VatandasKisiselDto:IDto
    {
        public string evAdres { get; set; }
        public string email { get; set; }
        public string ceptelefonNumarasi { get; set; }
    }
}
