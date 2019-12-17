using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Core.Utilities.Handlers._Exception
{
  public class Error
    {
        public ErrorDetails error { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
