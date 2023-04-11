using CoolTech.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CoolTechAPI.Services
{
    /// <summary>
    /// Used to store and retrive the records
    /// </summary>
    public interface ISalesService
    {
        Task<IActionResult> CheckSalesOrderStatus(string operationCode, string branch);
        Task<IActionResult> GetWmsDistribution(string operationCode, string docType, string docNo, string wmsStatus, string branch);
        Task<IActionResult> PostWmsDistribution(UIDistributionModel distributionModel);
    }
}
