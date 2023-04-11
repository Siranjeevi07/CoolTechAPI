using BusinessLogicLayer.Sales;
using CoolTech.Utilities;
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
                ApiResponse<string>.BadRequestObjectResult("Error while processing the CheckSalesOrder" + ex.Message);

            }
            return ApiResponse<List<CheckSalesOrderStatModel>>.OkObjectResult(checkSales);
        }

        public async Task<IActionResult> GetWmsDistribution(string operationCode, string docType, string docNo, string wmsStatus)
        {

            try
            {
                if (operationCode == "N")
                {
                    List<NDistribution> nDistributions = new List<NDistribution>();
                    nDistributions = await _salesBL.GetNDistribution(operationCode, docType, docNo, wmsStatus);
                    return ApiResponse<List<NDistribution>>.OkObjectResult(nDistributions);
                }
                else if (operationCode == "SOD")
                {
                    List<SODDistribution> sODDistributions = new List<SODDistribution>();
                    sODDistributions = await _salesBL.GetSODDistribution(operationCode, docType, docNo, wmsStatus);
                    return ApiResponse<List<SODDistribution>>.OkObjectResult(sODDistributions);
                }


                else if (operationCode == "V")
                {
                    List<VDistribution> vDistributions = new List<VDistribution>();
                    vDistributions = await _salesBL.GetVDistribution(operationCode, docType, docNo, wmsStatus);
                    return ApiResponse<List<VDistribution>>.OkObjectResult(vDistributions);
                }
                else if (operationCode == "V1")
                {
                    List<V1Distribution> v1Distributions = new List<V1Distribution>();
                    v1Distributions = await _salesBL.GetV1Distribution(operationCode, docType, docNo, wmsStatus);
                    return ApiResponse<List<V1Distribution>>.OkObjectResult(v1Distributions);
                }
            }
            catch (Exception ex)
            {
                ApiResponse<string>.BadRequestObjectResult("Error while processing the CheckSalesOrder" + ex.Message);

            }
            return ApiResponse<DataSet>.BadRequestObjectResult("Invalid Operation Code");
        }
        public async Task<IActionResult> PostWmsDistribution(UIDistributionModel distributionModel)
        {
            List<CheckSalesOrderStatModel> checkSales = new List<CheckSalesOrderStatModel>();
            try
            {
                //checkSales = await _salesBL.CheckSalesOrderStatus(operationCode);
            }
            catch (Exception ex)
            {
                ApiResponse<string>.BadRequestObjectResult("Error while processing the CheckSalesOrder" + ex.Message);

            }
            return ApiResponse<List<CheckSalesOrderStatModel>>.OkObjectResult(checkSales);
        }


    }
}
