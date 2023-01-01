using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace menu_api.Models;
public class Order : MongoDbEntity
{
    public string? TableId { get; set; }
    public List<MenuItem>? MenuItem { get; set; }
    public DateTime OrderedAt { get; set; } 

}
