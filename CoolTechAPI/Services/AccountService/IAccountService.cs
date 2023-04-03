using Microsoft.AspNetCore.Mvc;

namespace CoolTechAPI.Services
{
    public interface IAccountService
    {
        /// <summary>
        /// To login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="IMEI"></param>
        /// <returns></returns>
        Task<IActionResult> Login(string username, string password, string IMEI);
    }
}
