using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace menu_api.Models;

public class MenuItem : MongoDbEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string Category { get; set; }
    public string Desc { get; set; }

}
