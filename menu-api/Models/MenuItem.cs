using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace menu_api.Models;

public class MenuItem : MongoDbEntity
{
    public string? Name { get; set; }
    public int Price { get; set; }
    public string? Category { get; set; }
    public string? Image { get; set; }  
    public string? Desc { get; set; }

}
