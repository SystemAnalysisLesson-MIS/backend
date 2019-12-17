using IkematgahDegisim.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Entity.Concerete.Dtos.Kullanici
{
    public class KullaniciRegisterDto:IDto
    {
        public string ad { get; set; }
        public string soyad { get; set; }

        public string kullaniciAdi { get; set; }

        public string email { get; set; }

        public string ceptelefonNumarasi { get; set; }
        public string sifre { get; set; }
    }
}
