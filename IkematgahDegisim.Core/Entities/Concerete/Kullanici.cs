using IkematgahDegisim.Core.Entities.Abstract;
using System;

namespace IkematgahDegisim.Core.Entities.Concerete
{
   public class Kullanici:IEntity
    {
        public int Id { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }

        public string kullaniciAdi { get; set; }
        public string ceptelefonNumarasi { get; set; }
        public string email { get; set; }
        public byte[] sifreSalt { get; set; }
        public byte[] sifreHash { get; set; }

        public string refreshToken { get; set; }
        public DateTime? refreshTokenEndDate { get; set; }
        public bool durum { get; set; }
    }
}
