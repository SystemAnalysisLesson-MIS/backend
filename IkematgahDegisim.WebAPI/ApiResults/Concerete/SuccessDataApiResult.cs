using IkematgahDegisim.WebAPI.ApiResults.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IkematgahDegisim.WebAPI.ApiResults.Concerete
{
    public class SuccessDataApiResult : IDataApiResult
    {
        public object data { get; set; }
        public string message { get; set; }
    }
}
