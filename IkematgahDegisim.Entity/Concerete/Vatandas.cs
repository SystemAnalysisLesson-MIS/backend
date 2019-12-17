
using IkematgahDegisim.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IkematgahDegisim.Entity.Concerete
{
    public class Vatandas:IEntity
    {
        
        public int Id { get; set; }

        public string ad { get; set; }

        public string soyad { get; set; }

        public int tcKimlik { get; set; }

        public DateTime? dogumTarih { get; set; }

        public int? ikematgahId { get; set; }

        public Ikematgah ikematgah { get; set; } 
        public VatandasTalep vatandasTalep { get; set; }
        public VatandasTeslimat vatandasTeslimat { get; set; }
        public VatandasKisisel vatandasKisisel { get; set; }

      

       


    }
}
