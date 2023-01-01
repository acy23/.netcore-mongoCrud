using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace menu_api.Models;
public class Order : MongoDbEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string TableId { get; set; }
    public List<MenuItem> MenuItem { get; set; }
    public DateTime OrderedAt { get; set; } 

}
