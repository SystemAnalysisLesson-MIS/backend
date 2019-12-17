using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IkematgahDegisim.WebAPI.ApiResults.Abstract;
using IkematgahDegisim.WebAPI.ApiResults.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IkematgahDegisim.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {     
        private IApiResult response { get; set; }
        [Route("{code}")]
        public IActionResult Error(int code)
        {
            HttpStatusCode statuscode = (HttpStatusCode)code;
            var result = response.ReturnErrorResponse(statuscode.ToString(), (int)statuscode);
            return new ObjectResult(result);
        }
    }
}