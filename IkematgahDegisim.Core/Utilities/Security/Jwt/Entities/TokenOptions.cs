﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Core.Utilities.Security.Jwt.Entities
{
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        //public int RefreshTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
