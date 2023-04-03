using BusinessLogicLayer.Sales;
using CoolTechAPI.Hub;
using Microsoft.AspNetCore.SignalR;

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

        public string CheckSalesStatus()
        {
           return _salesBL.CheckSalesStatus();
        }


    }
}
