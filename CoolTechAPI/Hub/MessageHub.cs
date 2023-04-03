using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;

namespace CoolTechAPI.Hub
{
    public class MessageHub : Hub<IMessageHubClient>
    {
        public async Task CheckSalesStatus(List<string> message)
        {
            await Clients.All.CheckSalesStatus(message);
        }
    }
}
