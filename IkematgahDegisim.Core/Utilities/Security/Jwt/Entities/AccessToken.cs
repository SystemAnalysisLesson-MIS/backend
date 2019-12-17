using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Core.Utilities.Security.Jwt.Entities
{
    public class AccessToken
    {
        public string token { get; set; }
        public DateTime expireDate { get; set; }
        //public string refreshToken { get; set; }
    }
}
