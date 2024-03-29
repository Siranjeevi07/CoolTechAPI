﻿using CoolTech.Utilities;
using CoolTechAPI.Hub;
using CoolTechAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CoolTechAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        public readonly ISalesService _salesService;
       
        /// <summary>
        /// Sales controller to initilize the sales service 
        /// </summary>
        /// <param name="salesService"></param>
        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }
             
       
        /// <summary>
        /// To check the sales Status using SignalR
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("checksalesorderstatus")]
        public async Task<IActionResult> CheckSalesOrderStatus(string operationCode, string branch)
        {
           return await _salesService.CheckSalesOrderStatus(operationCode, branch);
            //List<string> offers = new List<string>();
            //offers.Add("Test Products 1");
            //offers.Add("Test Products 2");
            //_hubContext.Clients.All.CheckSalesStatus(offers);
          //  return null;
        }

        [HttpGet]
        [Route("getwmsdistribution")]
        public async Task<IActionResult> GetWmsDistribution(string operationCode,string docType, string docNo, string wmsStatus, string branch)
        {
            return await _salesService.GetWmsDistribution(operationCode,docType, docNo,wmsStatus, branch);
        }

        [HttpPost]
        [Route("postwmsdistribution")]
        public async Task<IActionResult> PostWmsDistribution([FromBody] UIDistributionModel distributionModel)
        {
            return null;
        }
       

    }
}
