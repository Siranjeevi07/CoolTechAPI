using Microsoft.AspNetCore.Mvc;

namespace CoolTechAPI.Services
{
    /// <summary>
    /// Used to store and retrive the records
    /// </summary>
    public interface ISalesService
    {
        Task<IActionResult> CheckSalesOrderStatus(string operationCode);
    }
}
