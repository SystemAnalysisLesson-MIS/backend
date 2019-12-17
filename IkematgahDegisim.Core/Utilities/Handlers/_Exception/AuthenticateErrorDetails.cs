using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Core.Utilities.Handlers._Exception
{
   public class AuthenticateErrorDetails:ErrorDetails
    {
        public bool? isTokenExpired { get; set; }
    }
}
