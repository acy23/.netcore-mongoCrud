using menu_api.Models;
using Microsoft.Extensions.Options;

namespace menu_api.Services
{
    public class OrderService : MongoOpsService<Order>
    {
        public OrderService(IOptions<MenuDatabaseSettings> menuDatabaseSettings) : base(menuDatabaseSettings)
        {
        }
    }
}
