using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;

namespace CoolTechAPI.Hub
{
    public class MessageHub : Hub<IMessageHubClient>

    {

        public async Task SendOffersToUser(List<string> message)
        {
            await Clients.All.SendOffersToUser(message);
        }
    }
}
