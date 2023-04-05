using CoolTech.Utilities;
using CoolTechAPI.Common;
using Microsoft.AspNetCore.Mvc;

namespace CoolTechAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient httpClient = new HttpClient();
        string loginURL = string.Empty;

        public IConfiguration _configuration { get; }
        public AccountService(IConfiguration configuration)
        {

            _configuration = configuration;
            loginURL = configuration.GetSection("URLs:LoginAPI").Value;
        }

        public AccountService()
        {

        }

        /// <summary>
        /// To llgin
        /// </summary>
        /// <param name="username"></param>
        /// <param name="fcmToken"></param>
        /// <param name="IMEI"></param>
        /// <returns></returns>
        public async Task<IActionResult> Login(string userName, string fcMToken, string imei)
        {

            //var data = new { UserName = "YAS", fcmToken = "sample string 2", IMEI ="3" };
            var data = new { UserName = userName, fcmToken = fcMToken, IMEI = imei };
            if (string.IsNullOrEmpty(loginURL)) {
                return ApiResponse<string>.BadRequestObjectResult("LoginURL is empty, add the correct URL in the app config");
            }
            string url = loginURL;// "http://ainryd.bizmagneterp.net:3047/api/Users/Login";
            var response = httpClient.PostAsync(url, data.AsJson());
            var responseString = await response.Result.Content.ReadAsStringAsync();
             
            return ApiResponse<string>.OkObjectResult(responseString);
        }

        

    }
}
