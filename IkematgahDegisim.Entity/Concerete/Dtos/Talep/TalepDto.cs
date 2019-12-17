using IkematgahDegisim.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Entity.Concerete.Dtos.Talep
{
    public class TalepDto:IDto
    {
        public bool kiraci { get; set; }
        
        public string kalinanEvinAdresi { get; set; }
        public byte[] sozlesmeFotograf { get; set; }
        public DateTime? talepTarihi { get; set; }
        public bool onay { get; set; }
    }
}
