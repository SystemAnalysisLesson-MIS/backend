using IkematgahDegisim.WebAPI.ApiResults.Abstract;
using IkematgahDegisim.WebAPI.ApiResults.Concerete;
using IkematgahDegisim.WebAPI.ApiResults.Concerete.Error;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IkematgahDegisim.WebAPI.ApiResults.Extensions
{
    public static class ApiJsonResultExtension
    {
        private static string JsonSerilazitionToModel(this IApiResult response)
        {
            return JsonConvert.SerializeObject(response, Formatting.Indented);
        }

        public static string ReturnErrorResponse(this IApiResult response, string? message, int code)
        {
            response = new ErrorApiResult
            {
                error = new ErrorResultDetail
                {
                    code = code,
                    message = message
                }
            };

            return response.JsonSerilazitionToModel();
        }

        public static string ReturnSuccessResponse(this IApiResult response, string? message)
        {
            response = new SuccessApiResult
            {
                message = message
            };

            return response.JsonSerilazitionToModel();
        }


        public static string ReturnSuccessDataResponse(this IDataApiResult response, object? data,string message)
        {
            response = new SuccessDataApiResult
            {
                data = data,
                message=message
            };

            return response.JsonSerilazitionToModel();
        }


    }
}
