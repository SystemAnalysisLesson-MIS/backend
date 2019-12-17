using IkematgahDegisim.WebAPI.ApiResults.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IkematgahDegisim.WebAPI.ApiResults.Concerete.Error
{
    public class ErrorApiResult : IApiResult
    {

        public ErrorResultDetail error { get; set; }
    }
}
