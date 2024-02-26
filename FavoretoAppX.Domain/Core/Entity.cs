using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FavoretoAppX.Domain.Core;

public class Entity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
}