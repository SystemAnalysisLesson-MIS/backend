using IkematgahDegisim.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Entity.Concerete.Dtos.Ikematgah
{
    public class IkematgahDto:IDto
    {
        public int Id { get; set; }
        public string? ikematgahAdres { get; set; }
    }
}
