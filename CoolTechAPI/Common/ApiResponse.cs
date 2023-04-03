using Microsoft.AspNetCore.Mvc;
using System.Net;
using CoolTech.Utilities;

namespace CoolTechAPI.Common
{
    public class ApiResponse<T>
    {

        public int StatusCode { get; set; }
        public string StatusText { get; set; }
        public T Data { get; set; }
        public List<Error<T>> Errors { get; set; }

        public static BadRequestObjectResult BadRequestObjectResult(string errorMessage)
        {
            var apiResponses = new ApiResponse<string>();
            apiResponses.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
            apiResponses.StatusText = HttpStatusCode.BadRequest.ToString();
            apiResponses.Errors = new List<Error<string>> { new Error<string> { Message = errorMessage } };
            return new BadRequestObjectResult(apiResponses);
        }

        public static OkObjectResult OkObjectResult(T data)
        {
            var apiResponses = new ApiResponse<T>();
            apiResponses.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            apiResponses.StatusText = HttpStatusCode.OK.ToString();
            apiResponses.Data = data;
            return new OkObjectResult(apiResponses);
        }
    }
}
