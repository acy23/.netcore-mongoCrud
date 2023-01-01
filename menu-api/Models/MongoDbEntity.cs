using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace menu_api.Models;

public class MongoDbEntity : IEntity<string>
{
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonId]
    [BsonElement(Order = 0)]
    public string Id { get; } = ObjectId.GenerateNewId().ToString();
}
