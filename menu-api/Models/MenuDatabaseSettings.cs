namespace menu_api.Models;

public class MenuDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string Collection { get; set; } = null!;
}
