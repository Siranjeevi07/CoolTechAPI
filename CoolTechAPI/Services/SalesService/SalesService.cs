using BusinessLogicLayer.Sales;
using CoolTech.Utilities.Models;
using CoolTechAPI.Common;
using CoolTechAPI.Hub;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Data;

namespace CoolTechAPI.Services
{

    /// <summary>
    /// Used to retrive and store the records 
    /// </summary>
    public class SalesService : ISalesService
    {
        private IHubContext<MessageHub, IMessageHubClient> _hubContext;
        private readonly ISalesBL _salesBL;
        public SalesService(IHubContext<MessageHub, IMessageHubClient> hubContext, ISalesBL salesBL)
        {
            _hubContext = hubContext;
            _salesBL = salesBL;
        }

        public async Task<IActionResult> CheckSalesOrderStatus(string operationCode)
        {
            List<CheckSalesOrderStatModel> checkSales = new List<CheckSalesOrderStatModel>();
            try
            {
                checkSales = await _salesBL.CheckSalesOrderStatus(operationCode);
            }
            catch (Exception ex)
            {
                ApiResponse<string>.BadRequestObjectResult("Error while processing the CheckSalesOrder" +ex.Message );

            }
            return ApiResponse<List<CheckSalesOrderStatModel>>.OkObjectResult(checkSales);
        }


    }
}
