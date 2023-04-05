using CoolTechAPI.Hub;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CoolTechAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class ProductController
    {
        private IHubContext<MessageHub, IMessageHubClient> _hubContext;
        public ProductController(IHubContext<MessageHub, IMessageHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

        //[HttpPost]
        //[Route("getproducts")]
        //public string Get()
        //{ 
        //  List<string> offers = new List<string>();
        //    offers.Add("Test Products 1");
        //    offers.Add("Test Products 2");
        //    _hubContext.Clients.All.SendOffersToUser(offers);
        //    return "Products send successfully";
        //}
    }
}
