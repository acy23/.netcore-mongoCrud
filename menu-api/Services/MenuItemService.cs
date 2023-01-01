using menu_api.Models;
using Microsoft.Extensions.Options;

namespace menu_api.Services;
public class MenuItemService : MongoOpsService<MenuItem>
{
    public MenuItemService(IOptions<MenuDatabaseSettings> menuDatabaseSettings) : base(menuDatabaseSettings)
    {
    }
}
