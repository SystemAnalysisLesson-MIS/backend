using IkematgahDegisim.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Entity.Concerete.Dtos.Vatandas
{
    public class VatandasDto:IDto
    {
       

        public string ad { get; set; }

        public string soyad { get; set; }

        public int tcKimlik { get; set; }

        public DateTime? dogumTarihi { get; set; }

        public int? ikematgahId { get; set; }
    }
}
