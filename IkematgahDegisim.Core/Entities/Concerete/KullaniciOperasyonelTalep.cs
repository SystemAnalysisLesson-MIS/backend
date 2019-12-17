using IkematgahDegisim.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Core.Entities.Concerete
{
    public class KullaniciOperasyonelTalep:IEntity
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int operationClaimId { get; set; }

        public Kullanici kullanici { get; set; }

        public OperasyonelTalep operasyonelTalep { get; set; }
    }
}
