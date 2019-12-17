using IkematgahDegisim.Core.Entities.Concerete;
using IkematgahDegisim.Core.Utilities.Security.Jwt.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Core.Utilities.Security.Jwt.Abstract
{
   public interface ITokenHelper
    {
        AccessToken CreateToken(Kullanici kullanici, List<OperasyonelTalep> operasyonelTalepler);


    }
}
