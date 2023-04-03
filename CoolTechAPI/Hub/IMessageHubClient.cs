namespace CoolTechAPI.Hub
{
    public interface IMessageHubClient
    {
        Task SendOffersToUser(List<string> message);

        Task CheckSalesStatus(List<string> message);
    }
}
