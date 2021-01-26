using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace OnlineShoppingStore.Hubs
{
    [HubName("OrdersHub")]
    public class OrdersHub : Hub
    {
        public static void BroadcastData()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<OrdersHub>();
            context.Clients.All.refreshOrdersData();
        }
    }
}