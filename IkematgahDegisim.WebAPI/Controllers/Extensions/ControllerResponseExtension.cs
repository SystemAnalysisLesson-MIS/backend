using IkematgahDegisim.WebAPI.ApiResults.Abstract;
using IkematgahDegisim.WebAPI.ApiResults.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IkematgahDegisim.WebAPI.Controllers.Extensions
{
    public static class ControllerResponseExtension
    {
        private static IApiResult apiResponse { get; set; }
        private static IDataApiResult dataApiResponse { get; set; }
        public static OkObjectResult OkWithData(this ControllerBase controllerBase, object? data,string message)
        {
            return controllerBase.Ok($"{dataApiResponse.ReturnSuccessDataResponse(data,message)}");
        }

        public static OkObjectResult OkWithMessage(this ControllerBase controllerBase, string? message)
        {
            return controllerBase.Ok($"{apiResponse.ReturnSuccessResponse(message)}");
        }

        public static BadRequestObjectResult BadRequestWithMessage(this ControllerBase controllerBase, string? message)
        {
            return controllerBase.BadRequest($"{apiResponse.ReturnErrorResponse(message, 400)}");
        }
    }
}
