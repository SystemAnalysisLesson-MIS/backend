using IkematgahDegisim.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Entity.Concerete
{
    public class Talep:IEntity
    {

        public int Id { get; set; }

        public string kalinanEvinAdresi { get; set; }
        public bool kiraci { get; set; }
        public byte[] sozlesmeFotograf { get; set; }
        public DateTime? talepTarihi { get; set; }



        public bool onay { get; set; }
        public VatandasTalep vatandasTalep { get; set; }
        

    }
}
