using IkematgahDegisim.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Core.Entities.Concerete
{
   public class OperasyonelTalep:IEntity
    {
        public int Id { get; set; }
        public string name { get; set; }
    }
}
