using CoolTechAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoolTechAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IAccountService _accountService;

        /// <summary>
        /// To manage the account details including authorization and authentication
        /// </summary>
        /// <param name="accountService"></param>
        public AccountController(IAccountService accountService)
        {
            this._accountService = accountService;
        }

        /// <summary>
        /// TO login
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="fcmToken"></param>
        /// <param name="IMEI"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(string userName, string fcmToken, string IMEI)
        {
           return await _accountService.Login(userName, fcmToken, IMEI);
        }

        /// <summary>
        /// To logout
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("signOut")]
        public string SignOut(string returnUrl)
        {
            return string.Empty;
        }
    }
}
